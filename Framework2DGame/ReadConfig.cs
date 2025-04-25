using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Framework2DGame
{
    /// <summary>
    /// Config reader to save the information in the configuration file
    /// </summary>
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
            try
            {
                configXML.Load("../../../Config.xml");
            }
            catch (Exception ex)
            {
                LoggingClass.Critical("Failed to load Config file");
            }

            

            XmlNode? MaxX_XML = configXML.DocumentElement.SelectSingleNode("World/WorldSize/MaxX");
            if (MaxX_XML != null)
            {
                string maxXTxt = MaxX_XML.InnerText.Trim();
                maxX = Convert.ToInt32(maxXTxt);
            }
            else
            {
                LoggingClass.Warning("MaxX not found in Config");
            }

            XmlNode? MaxY_XML = configXML.DocumentElement.SelectSingleNode("World/WorldSize/MaxY");
            if (MaxY_XML != null)
            {
                string maxYTxt = MaxY_XML.InnerText.Trim();
                maxY = Convert.ToInt32(maxYTxt);
            }
            else
            {
                LoggingClass.Warning("MaxY not found in Config");
            }

            XmlNode? LevelXML = configXML.DocumentElement.SelectSingleNode("World/Level");
            if (LevelXML != null)
            {
                level = LevelXML.InnerText;
            }
            else
            {
                LoggingClass.Warning("Level not found in Config");
            }

        }
        

    }
}
