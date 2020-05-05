using CrazyElephant.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CrazyElephant.Services
{
    class XmlDataService : IDataService
    {
        public List<Dish> GetAllDishes()
        {
            List<Dish> dishList = new List<Dish>();
            string xmlFileName = Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
            var xDoc = XDocument.Load(xmlFileName);
            var dishes = xDoc.Descendants("Dish");
            foreach (var dish in dishes)
            {
                var dishItem = new Dish();
                dishItem.Name = dish.Element("Name").Value;
                dishItem.Category = dish.Element("Category").Value;
                dishItem.Comment = dish.Element("Comment").Value;
                dishItem.Score = double.Parse(dish.Element("Score").Value);
                dishList.Add(dishItem);
            }
            return dishList;
        }
    }
}
