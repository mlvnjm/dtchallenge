using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace DealerTrack.Models
{
    public class CsvFileManager : IFileManager
    {
        public List<Deal> ParseFileData(IFormFile file)
        {
            var dealList = new List<Deal>();

            using (var reader = new StreamReader(file.OpenReadStream(), Encoding.GetEncoding("iso-8859-1")))
            {
                //ignore first line
                var headerLine = reader.ReadLine();

                while(reader.Peek() >=0)
                {

                    var line = reader.ReadLine();
                    //remove comma and double quote from price field
                    line = Regex.Replace(line, "\"(\\d+),(\\d+)\"", "$1$2");
                    var data = line.Split(',');

                    //expecting 6 columns in each row
                    if (data.Length == 6)
                    {
                        var deal = new Deal();
                        if (int.TryParse(data[0], out var dealNumber))
                            deal.DealNumber = dealNumber;
                        deal.CustomerName = data[1];
                        deal.DealershipName = data[2];
                        deal.Vehicle = data[3];
                        if (decimal.TryParse(data[4], out var parsedPrice))
                            deal.Price = parsedPrice;
                        if (DateTime.TryParse(data[5], out var date))
                            deal.Date = date;

                        dealList.Add(deal);
                    }
                }
            }

            return dealList;
        }
    }
}
