using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Gestpsfe.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
       
            private readonly ILogger<ExcelController> _logger;
            private readonly PfeContext _dbContext;
         
            public ExcelController(ILogger<ExcelController> logger, PfeContext dbContext)
            {
                _logger = logger;
                _dbContext = dbContext;
            }

            [HttpPost("ImportData")]
            public IActionResult ImportData(IFormFile file)
            {
                try
                {
                    if (file == null || file.Length <= 0)
                        return BadRequest("No file uploaded.");

                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(memoryStream, false))
                        {
                            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                            Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().FirstOrDefault();

                            if (sheet != null)
                            {
                                WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                                Worksheet worksheet = worksheetPart.Worksheet;
                                SharedStringTablePart stringTablePart = workbookPart.SharedStringTablePart;

                                // Get the row data from the worksheet
                                IEnumerable<Row> rows = worksheet.Descendants<Row>();

                                // Skip the header row if needed
                                bool skipHeaderRow = true;

                                foreach (Row row in rows)
                                {
                                    // Skip the header row
                                    if (skipHeaderRow)
                                    {
                                        skipHeaderRow = false;
                                        continue;
                                    }

                                    var newRow = new ListePlanification();

                                    int columnIndex = 1;

                                    foreach (Cell cell in row.Elements<Cell>())
                                    {
                                        string cellValue = GetCellValue(cell, stringTablePart);

                                        switch (columnIndex)
                                        {
                                         
                                            case 1:
                                            newRow.PlanificationName = cellValue;
                                            
                                                break;
                                            case 2:
                                                newRow.Entre = DateTime.Parse(cellValue);
                                            break;
                                        case 3:
                                            newRow.Sortie = DateTime.Parse(cellValue);
                                            break;
                                        case 4:
                                            newRow.Repos = DateTime.Parse(cellValue);
                                            break;
                                            // Add more cases for additional columns
                                    }

                                        columnIndex++;
                                    }

                                    _dbContext.ListePlanifications.Add(newRow);
                                }

                                _dbContext.SaveChanges();
                            }
                        }
                    }

                    return Ok("Data imported successfully.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error importing data from Excel.");
                    return StatusCode(500, "An error occurred while importing data from Excel."+ ex);
                }
            }

            private string GetCellValue(Cell cell, SharedStringTablePart stringTablePart)
            {
                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    int sharedStringIndex = int.Parse(cell.CellValue.Text);
                    return stringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(sharedStringIndex).InnerText;
                }
                else
                {
                    return cell.CellValue?.Text ?? string.Empty;
                }
            }
        }
    
}
