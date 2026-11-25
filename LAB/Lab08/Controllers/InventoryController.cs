
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Lab08.Models;

namespace Lab08.Controllers
{
    public class InventoryController : Controller
    {
        private readonly string connectionString;

        public InventoryController(IConfiguration configuration)
        {
            connectionString =
                configuration.GetConnectionString("InventoryConnection")!;
        }

        // READ: Display all inventory items
        public IActionResult Index()
        {
            List<InventoryItem> items = new List<InventoryItem>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, ItemName, Quantity,
                                 PricePerUnit, TotalPrice
                                 FROM InventoryItems";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new InventoryItem
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ItemName = reader["ItemName"].ToString()!,
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            PricePerUnit = Convert.ToDecimal(
                                reader["PricePerUnit"]),
                            TotalPrice = Convert.ToDecimal(
                                reader["TotalPrice"])
                        });
                    }
                }
            }

            return View(items);
        }

        // CREATE: Display the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Insert a new item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InventoryItem item)
        {
            if (string.IsNullOrWhiteSpace(item.ItemName) ||
                item.ItemName.Trim().Length > 100 ||
                item.Quantity < 0 ||
                item.PricePerUnit < 0 ||
                item.PricePerUnit > 99999999.99m)
            {
                ViewBag.Error =
                    "Enter a valid name, quantity and unit price.";
                return View(item);
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO InventoryItems
                                 (ItemName, Quantity, PricePerUnit)
                                 VALUES
                                 (@ItemName, @Quantity, @PricePerUnit)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar, 100)
                    .Value = item.ItemName.Trim();

                cmd.Parameters.Add("@Quantity", SqlDbType.Int)
                    .Value = item.Quantity;

                SqlParameter priceParameter =
                    cmd.Parameters.Add("@PricePerUnit", SqlDbType.Decimal);

                priceParameter.Precision = 10;
                priceParameter.Scale = 2;
                priceParameter.Value = item.PricePerUnit;

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction(nameof(Index));
        }

        // UPDATE: Display the selected item
        [HttpGet]
        public IActionResult Edit(int id)
        {
            InventoryItem? item = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, ItemName, Quantity,
                                 PricePerUnit, TotalPrice
                                 FROM InventoryItems
                                 WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        item = new InventoryItem
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ItemName = reader["ItemName"].ToString()!,
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            PricePerUnit = Convert.ToDecimal(
                                reader["PricePerUnit"]),
                            TotalPrice = Convert.ToDecimal(
                                reader["TotalPrice"])
                        };
                    }
                }
            }

            if (item == null)
                return NotFound();

            return View(item);
        }

        // UPDATE: Save changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InventoryItem item)
        {
            if (string.IsNullOrWhiteSpace(item.ItemName) ||
                item.ItemName.Trim().Length > 100 ||
                item.Quantity < 0 ||
                item.PricePerUnit < 0 ||
                item.PricePerUnit > 99999999.99m)
            {
                ViewBag.Error =
                    "Enter a valid name, quantity and unit price.";
                return View(item);
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE InventoryItems
                                 SET ItemName = @ItemName,
                                     Quantity = @Quantity,
                                     PricePerUnit = @PricePerUnit
                                 WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = item.Id;

                cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar, 100)
                    .Value = item.ItemName.Trim();

                cmd.Parameters.Add("@Quantity", SqlDbType.Int)
                    .Value = item.Quantity;

                SqlParameter priceParameter =
                    cmd.Parameters.Add("@PricePerUnit", SqlDbType.Decimal);

                priceParameter.Precision = 10;
                priceParameter.Scale = 2;
                priceParameter.Value = item.PricePerUnit;

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // DELETE: Display confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            InventoryItem? item = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, ItemName, Quantity,
                                 PricePerUnit, TotalPrice
                                 FROM InventoryItems
                                 WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        item = new InventoryItem
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ItemName = reader["ItemName"].ToString()!,
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            PricePerUnit = Convert.ToDecimal(
                                reader["PricePerUnit"]),
                            TotalPrice = Convert.ToDecimal(
                                reader["TotalPrice"])
                        };
                    }
                }
            }

            if (item == null)
                return NotFound();

            return View(item);
        }

        // DELETE: Remove the item
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query =
                    "DELETE FROM InventoryItems WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}