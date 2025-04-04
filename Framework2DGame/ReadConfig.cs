using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Framework2DGame
{
    public class ReadConfig
    {
        public int maxX;
        public int maxY;
        public string? level;

        /// <summary>
        /// Reads the config xml and stores the different parameters to use in the others classes
        /// </summary>
        public void Start()
        {
            XmlDocument configXML = new XmlDocument();
            configXML.Load("../../../Config.xml");

            XmlNode? MaxX_XML = configXML.DocumentElement.SelectSingleNode("World/WorldSize/MaxX");
            if (MaxX_XML != null)
            {
                string maxXTxt = MaxX_XML.InnerText.Trim();
                maxX = Convert.ToInt32(maxXTxt);
            }

            XmlNode? MaxY_XML = configXML.DocumentElement.SelectSingleNode("World/WorldSize/MaxY");
            if (MaxY_XML != null)
            {
                string maxYTxt = MaxY_XML.InnerText.Trim();
                maxY = Convert.ToInt32(maxYTxt);
            }

            XmlNode? LevelXML = configXML.DocumentElement.SelectSingleNode("World/Level");
            if (LevelXML != null)
            {
                level = LevelXML.InnerText;
            }

        }
        

    }
}
