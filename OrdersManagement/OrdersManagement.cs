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

namespace OrdersManagement
{
    public partial class OrdersManagement : Form
    {
        public OrdersManagement()
        {
            InitializeComponent();
        }

        SecureCoreEntities db;
        Order currentOrder = null;

        private void InsertDataFromEDI(string filePath)
        {
            // Initialize the database context
            db = new SecureCoreEntities();

            // Read all lines from the provided EDI file
            var lines = File.ReadAllLines(filePath);

            // Loop through each line in the file
            foreach (var line in lines)
            {
                // Split the line into parts using '|' as the delimiter
                var parts = line.Split('|');

                // Check if the line is not empty
                if (parts.Length > 0)
                {
                    // Handle each line based on its prefix (the first part of the line)
                    switch (parts[0])
                    {
                        case "ORD":
                            // Process an 'ORD' line
                            HandleOrderLine(parts);
                            break;
                        case "DTM":
                            // Process a 'DTM' line
                            if (currentOrder != null)
                            {
                                HandleDTMLine(parts, currentOrder);
                            }
                            break;

                        case "NADMS":
                            // Process a 'NADMS' line
                            if (currentOrder != null)
                            {
                                HandleNADMSLine(parts, currentOrder);
                            }
                            break;
                        default:
                            // Handle any unrecognized line types
                            break;
                    }
                }
            }

            // Save all changes made to the database context
            db.SaveChanges();
        }

        private void HandleOrderLine(string[] parts)
        {
            // Ensure that the 'ORD' line has at least 3 parts
            if (parts.Length >= 3)
            {
                // Extract the order code and priority code from the line
                var codeOrder = parts[1];
                var codePriority = parts[2];

                // Check if a priority with the provided code already exists in the database
                var priority = db.Priorities.FirstOrDefault(p => p.CodePriority == codePriority);
                if (priority == null)
                {
                    // If it doesn't exist, create a new Priority object and add it to the database
                    priority = new Priority { CodePriority = codePriority };
                    db.Priorities.Add(priority);
                    // Save immediately to assign an ID to the new Priority
                    db.SaveChanges();
                }

                // Create a new Order object with the extracted order code
                var order = new Order
                {
                    codeOrder = codeOrder,
                    // Set the PriorityId to the ID of the found or newly added Priority
                    IdPriority = priority.idPriority
                };

                // Add the new Order object to the database
                db.Orders.Add(order);
            }
            else
            {
                // Optionally, handle the case where the 'ORD' line does not have enough parts
            }
        }

        private void HandleDTMLine(string[] parts, Order currentOrder)
        {
            // Ensure that the 'DTM' line has at least 2 parts
            if (parts.Length >= 2)
            {
                // Extract the date from the line
                var dateStr = parts[1];

                // Parse the date assuming it's in the format 'yyyyMMdd'
                if (DateTime.TryParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOrder))
                {
                    // Set the dateOrder property of the current order
                    currentOrder.dateOrder = dateOrder;
                }
             
            }
        }

        private void HandleNADMSLine(string[] parts, Order currentOrder)
        {
            // Ensure that the 'NADMS' line has at least 3 parts
            if (parts.Length >= 3)
            {
                // Extract the operational area code and agency code from the line
                var codeOperationalArea = parts[1];
                var codeAgency = parts[2];

                // Check if an operational area with the provided code already exists in the database
                var operationalArea = db.OperationalAreas.FirstOrDefault(oa => oa.CodeOperationalArea == codeOperationalArea);
                if (operationalArea == null)
                {
                    // If it doesn't exist, create a new OperationalArea object and add it to the database
                    operationalArea = new OperationalArea { CodeOperationalArea = codeOperationalArea };
                    db.OperationalAreas.Add(operationalArea);
                    // Save immediately to assign an ID to the new OperationalArea
                    db.SaveChanges();
                }

                // Check if an agency with the provided code already exists in the database
                var agency = db.Agencies.FirstOrDefault(a => a.CodeAgency == codeAgency);
                if (agency == null)
                {
                    // If it doesn't exist, create a new Agency object and add it to the database
                    agency = new Agency { CodeAgency = codeAgency };
                    db.Agencies.Add(agency);
                    // Save immediately to assign an ID to the new Agency
                    db.SaveChanges();
                }

                // Link the operational area and agency to the current order
                currentOrder.IdOperationalArea = operationalArea.IdOperationalArea; // Assuming there is a foreign key relationship
                currentOrder.IdAgency = agency.IdAgency; // Assuming there is a foreign key relationship
            }
            else
            {
                // Optionally, handle the case where the 'NADMS' line does not have enough parts
            }
        }

    }
}
