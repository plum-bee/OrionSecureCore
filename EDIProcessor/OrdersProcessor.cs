using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDIProcessor
{
    public partial class frmOrdersProcessor : Form
    {
        OrdersEntities db = new OrdersEntities();
        Order newOrder;
        OrderInfo newOrderInfo;
        OrdersDetail newOrderDetail;
        List<OrdersDetail> orderDetails;

        public frmOrdersProcessor()
        {
            InitializeComponent();
        }

        private string LoadEDIFile()
        {
            const string EDIFolderName = "EDIOrders";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string ediFolderPath = Path.Combine(basePath, EDIFolderName);

            if (!Directory.Exists(ediFolderPath))
            {
                Directory.CreateDirectory(ediFolderPath);
            }

            string[] ediFiles = Directory.GetFiles(ediFolderPath, "*.edi");

            if (ediFiles.Length > 0)
            {
                return ediFiles[0];
            }
            else
            {
                MessageBox.Show("No EDI files found in the folder " + EDIFolderName + ".");
                return null;
            }
        }

        private void LoadEDIOrder(string filePath)
        {
            if (filePath != null)
            {
                orderDetails = new List<OrdersDetail>();

                foreach (string line in File.ReadLines(filePath))
                {
                    string[] parts = line.Split('|');
                    switch (parts[0])
                    {
                        case "ORD":
                            newOrder = new Order
                            {
                                codeOrder = parts[1],
                                IdPriority = GetPriorityId(parts[2])
                            };
                            break;
                        case "DTM":
                            newOrder.dateOrder = FormatDate(parts[1]);
                            break;

                        case "NADMS":
                            newOrderInfo = new OrderInfo
                            {
                                idOperationalArea = GetOperationalAreaId(parts[1]),
                                idAgency = GetAgencyId(parts[2])
                            };
                            break;

                        case "NADMR":
                            newOrder.IdFactory = GetFactoryId(parts[1]);
                            break;

                        case "LIN":
                            newOrderDetail = new OrdersDetail
                            {
                                idPlanet = GetPlanetId(parts[1]),
                                idReference = GetReferenceId(parts[2])
                            };
                            break;
                        case "QTYLIN":
                            newOrderDetail.Quantity = GetQuantity(parts[1], parts[2]);
                            break;

                        case "DTMLIN":
                            newOrderDetail.DeliveryDate = FormatDate(parts[1]);
                            orderDetails.Add(newOrderDetail);
                            break;
                        default:
                            break;
                    }
                }
                SaveOrder();
                HandleProcessedEDI(filePath);
                DisplayOrder(newOrder);
            }
        }

        private void DisplayOrder(Order order)
        {
            var query = from o in db.Orders
                        join f in db.Factories on o.IdFactory equals f.idFactory
                        join oi in db.OrderInfoes on o.idOrder equals oi.idOrder
                        join a in db.Agencies on oi.idAgency equals a.idAgency
                        join oa in db.OperationalAreas on oi.idOperationalArea equals oa.idOperationalArea
                        join p in db.Priorities on o.IdPriority equals p.idPriority
                        where oi.idOrder == order.idOrder
                        select new
                        {
                            o.codeOrder,
                            o.dateOrder,
                            f.DescFactory,
                            a.DescAgency,
                            oa.DescOperationalArea
                        };

            DataTable dataTable = new DataTable("OrderDetails");
            dataTable.Columns.Add("Code", typeof(string));
            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("Factory", typeof(string));
            dataTable.Columns.Add("Agency", typeof(string));
            dataTable.Columns.Add("Area", typeof(string));

            foreach (var detail in query)
            {
                dataTable.Rows.Add(detail.codeOrder, detail.dateOrder, detail.DescFactory, detail.DescAgency, detail.DescOperationalArea);
            }

            dgvOrdersDetail.DataSource = dataTable;
            BindDataToFields(dataTable);
        }

        private void BindDataToFields(DataTable dataTable)
        {
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.Tag == null) continue;
                textBox.DataBindings.Clear();
                textBox.DataBindings.Add("Text", dataTable, textBox.Tag.ToString());
                textBox.Validated += OnTextBoxValidate;

                textBox.ReadOnly = true;
            }
        }

        private void OnTextBoxValidate(object sender, EventArgs e)
        {
            ((TextBox)sender).DataBindings[0].BindingManagerBase.EndCurrentEdit();
        }


        private void SaveOrder()
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    newOrder.OrderInfoes.Add(newOrderInfo);

                    foreach (var item in orderDetails)
                    {
                        newOrder.OrdersDetails.Add(item);
                    }

                    db.Orders.Add(newOrder);
                    db.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HandleProcessedEDI(string path)
        {
            string processedFolderPath = Path.Combine(Path.GetDirectoryName(path), "ProcessedOrders");

            if (!Directory.Exists(processedFolderPath))
            {
                Directory.CreateDirectory(processedFolderPath);
            }

            string dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);

            string newFileName = $"{fileNameWithoutExtension}_{dateTimeNow}{extension}";
            string newPath = Path.Combine(processedFolderPath, newFileName);

            File.Move(path, newPath);
        }

        private short GetPriorityId(string priorityCode)
        {
            return db.Priorities
                     .Where(p => p.CodePriority == priorityCode)
                     .Select(p => p.idPriority)
                     .FirstOrDefault();
        }

        public DateTime FormatDate(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        private short GetOperationalAreaId(string operationalCode)
        {
            return db.OperationalAreas
                     .Where(oa => oa.CodeOperationalArea == operationalCode)
                     .Select(oa => oa.idOperationalArea)
                     .FirstOrDefault();
        }

        private short GetAgencyId(string agencyCode)
        {
            return db.Agencies
                     .Where(a => a.CodeAgency == agencyCode)
                     .Select(a => a.idAgency)
                     .FirstOrDefault();
        }

        private short GetFactoryId(string factoryCode)
        {
            return db.Factories
                     .Where(f => f.codeFactory == factoryCode)
                     .Select(f => f.idFactory)
                     .FirstOrDefault();
        }

        private int GetPlanetId(string planetCode)
        {
            return db.Planets
                     .Where(p => p.CodePlanet == planetCode)
                     .Select(p => p.idPlanet)
                     .FirstOrDefault();
        }

        private short GetReferenceId(string referenceCode)
        {
            return db.References
                     .Where(r => r.codeReference == referenceCode)
                     .Select(r => r.idReference)
                     .FirstOrDefault();
        }

        private short GetQuantity(string qualifier, string quantity)
        {
            bool isQualifyingCode = int.Parse(qualifier) == 21;
            int parsedQuantity = int.Parse(quantity);

            return (short)(isQualifyingCode ? parsedQuantity : -parsedQuantity);
        }

        private void btnLoadEdiFile_Click(object sender, EventArgs e)
        {
            LoadEDIOrder(LoadEDIFile());
        }
    }
}
