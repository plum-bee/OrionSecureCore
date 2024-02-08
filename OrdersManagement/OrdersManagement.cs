using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdersManagement
{
    public partial class OrdersManagement : Form
    {
        public OrdersManagement()
        {
            InitializeComponent();
        }

        SecureCoreOrderEntities db;
        Orders currentOrder = null;

        List<Agencies> agenciesList = new List<Agencies>();
        List<OrderInfo> orderInfoList = new List<OrderInfo>();
        List<OrdersDetail> ordersDetailList = new List<OrdersDetail>();
        List<Planets> planetsList = new List<Planets>();
        List<Reference> referencesList = new List<Reference>();
        List<Orders> ordersList = new List<Orders>();
        List<Factories> factoriesList = new List<Factories>();
        List<Priority> prioritiesList = new List<Priority>();

        private void InsertDataFromEDI(string filePath)
        {
            db = new SecureCoreOrderEntities();

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                if (parts.Length > 0)
                {
                    switch (parts[0])
                    {
                        case "ORD":
                            HandleOrderLine(parts);
                            break;
                        case "DTM":
                            if (currentOrder != null)
                            {
                                HandleDTMLine(parts, currentOrder);
                            }
                            break;
                        case "NADMS":
                            if (currentOrder != null)
                            {
                                HandleNADMSLine(parts, currentOrder);
                            }
                            break;
                        case "NADMR":
                            if (currentOrder != null)
                            {
                                HandleNADMRLine(parts, currentOrder);
                            }
                            break;
                        case "LIN":
                            if (currentOrder != null)
                            {
                                HandleLINLine(parts, currentOrder);
                            }
                            break;
                        case "QTYLIN":
                            if (currentOrder != null)
                            {
                                HandleQTYLINLine(parts, currentOrder);
                            }

                            break;
                        case "DTMLIN":
                            if (currentOrder != null)
                            {
                                HandleDTMLINLine(parts, currentOrder);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            //db.SaveChanges();
        }

        private void HandleOrderLine(string[] parts)
        {
            if (parts.Length >= 3)
            {
                var codeOrder = parts[1];
                var codePriority = parts[2];

                var priority = db.Priority.FirstOrDefault(p => p.CodePriority == codePriority);

                var order = new Orders
                {
                    codeOrder = codeOrder,
                    IdPriority = priority.idPriority
                };

                ordersList.Add(order);
            }
        }

        private void HandleDTMLine(string[] parts, Orders currentOrder)
        {
            if (parts.Length >= 2)
            {
                var dateStr = parts[1];

                if (DateTime.TryParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDateTime))
                {
                    currentOrder.dateOrder = newDateTime;
                }
            }
        }

        private void HandleNADMSLine(string[] parts, Orders currentOrder)
        {
            if (parts.Length >= 3)
            {
                var codeOperationalArea = parts[1];
                var codeAgency = parts[2];

                var operationalArea = db.OperationalAreas.FirstOrDefault(oa => oa.CodeOperationalArea == codeOperationalArea);
                var agency = db.Agencies.FirstOrDefault(a => a.CodeAgency == codeAgency);

                var currentOrderInfo = db.OrderInfo.FirstOrDefault(oi => oi.idOrder == currentOrder.idOrder);

                if (currentOrderInfo == null) return;

                if (agency != null) currentOrderInfo.idAgency = agency.idAgency;
                if (operationalArea != null) currentOrderInfo.idOperationalArea = operationalArea.idOperationalArea;
            }
        }

        private void HandleNADMRLine(string[] parts, Orders currentOrder)
        {
            if (parts.Length >= 2)
            {
                var codeFactory = parts[1];

                var factory = db.Factories.FirstOrDefault(f => f.codeFactory == codeFactory);

                if (factory != null)
                {
                    currentOrder.IdFactory = factory.idFactory;
                }
            }
        }

        private void HandleLINLine(string[] parts, Orders currentOrder)
        {
            if (parts.Length >= 4)
            {
                var codePlanet = parts[1];
                var codeReference = parts[2];

                var planet = db.Planets.FirstOrDefault(p => p.CodePlanet == codePlanet);

                var reference = db.References.FirstOrDefault(r => r.codeReference == codeReference);

                var orderDetail = new OrdersDetail
                {
                    idOrder = currentOrder.idOrder,
                    idPlanet = planet.idPlanet,
                    idReference = reference.idReference
                };

                
            }
        }

        private void HandleQTYLINLine(string[] parts, Orders currentOrder)
        {
            if (parts.Length >= 3)
            {
                var qualifier = parts[1];
                var quantityStr = parts[2];

                if (!int.TryParse(quantityStr, out var quantity)) return;

                var orderDetail = new OrdersDetail
                {
                    idOrder = currentOrder.idOrder,
                    Quantity = (short?)(qualifier == "21" ? quantity : (qualifier == "61" ? -quantity : quantity))
                };

                db.OrdersDetail.Add(orderDetail);
            }
        }

        private void HandleDTMLINLine(string[] parts, Orders currentOrder)
        {
            if (parts.Length >= 2)
            {
                var deliveryDateStr = parts[1];

                if (DateTime.TryParseExact(deliveryDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryDate))
                {
                    var lastOrderDetail = db.OrdersDetail
                        .Where(od => od.idOrder == currentOrder.idOrder)
                        .OrderByDescending(od => od.idOrderDetail)
                        .FirstOrDefault();

                    if (lastOrderDetail != null)
                    {
                        lastOrderDetail.DeliveryDate = deliveryDate;
                    }

                }

            }

        }

    }
}
