using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace My
{
    public class XML
    {
        public static XmlTextWriter NewXML(string file)
        {
            XmlTextWriter xw = new XmlTextWriter(file, System.Text.Encoding.UTF8);
            xw.Formatting = System.Xml.Formatting.Indented;
            xw.Indentation = 4;
            xw.WriteStartDocument(true);
            return xw;
        }

        /// <summary>
        /// Vecchia funzione!!!
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static XmlTextWriter NewFile(string fileName)
        {
            XmlTextWriter xw = null;
            try
            {
                xw = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
                xw.Formatting = System.Xml.Formatting.Indented;
                xw.Indentation = 4;
                xw.WriteStartDocument(true);
            }
            catch (System.Exception ex)
            { My.Box.Info(ex.Message + "\n\n My::Xml::NewFile()"); }
            return xw;
        }

        public static void Close(XmlTextWriter xw)
        {
            xw.WriteEndDocument();
            xw.Flush(); xw.Close();
        }

        public static XmlDocument ReadXML(string file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            return doc;
        }

        public static string GetValue(XmlDocument doc, string element, string def)
        {   return GetAttribute(doc, element, "value", def);    }

        public static string GetAttribute(XmlDocument doc, string element, string attribute, string def)
        {
            try
            {
                XmlNodeList list = doc.GetElementsByTagName(element);
                if (list.Count > 0)
                {
                    XmlNode node = list.Item(0);
                    XmlAttribute att = node.Attributes[attribute];
                    if (att != null) return att.Value.ToString();
                }
            }
            catch (System.Exception ex)
            { My.Box.Errore(ex.Message); }
            return def;
        }

        public static void Write(XmlTextWriter xw, string elem, string val)
        {
            xw.WriteStartElement(elem);
            xw.WriteAttributeString("value", val);
            xw.WriteEndElement();
        }

        /// <summary>
        /// Scrive una lista di elementi in un file XML.
        /// </summary>
        /// <param name="xw">Documento XML in scrittura</param>
        /// <param name="elements">Nome del gruppo di elementi</param>
        /// <param name="element">Nome del singolo elemento</param>
        /// <param name="list">Lista contenente gli oggetti da salvare</param>
        public static void Write(XmlTextWriter xw, string elements, string element, System.Collections.ArrayList list)
        {
            xw.WriteStartElement(elements);
            foreach (object s in list) Write(xw, element, s.ToString());
            xw.WriteEndElement();
        }

        /// <summary>
        /// Vecchia funzione!!!
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Filter(string s)
        {
            string result = s.Replace("\r\n", "").TrimStart(null).TrimEnd(null);
            while (result.IndexOf("  ") != -1) result = result.Replace("  ", " ");
            return result;
        }

        /// <summary>
        /// Carica una lista di elementi da un file XML.
        /// </summary>
        /// <param name="doc">Documento XML in lettura</param>
        /// <param name="elements">Nome del gruppo di elementi</param>
        /// <param name="element">Nome del singolo elemento</param>
        /// <returns>La lista degli elementi caricati</returns>
        public static System.Collections.ArrayList GetList(XmlDocument doc, string elements, string element)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();
            XmlNodeList list = doc.GetElementsByTagName(elements);
            if (list.Count > 0)
            {
                XmlNode node = list.Item(0);
                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.Name == element)
                    {
                        if ((item.Attributes["value"] != null) && (item.Attributes["value"].Value != null))
                        {
                            lista.Add(item.Attributes["value"].Value.ToString());
                        }
                    }
                }
            }
            return lista;
        }

    }

    // MS-MAM Compatibility
    public class Xml
    {
        public static XmlTextWriter NewFile(string fileName)
        {
            XmlTextWriter xw = null;
            try
            {
                xw = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
                xw.Formatting = System.Xml.Formatting.Indented;
                xw.Indentation = 4;
                xw.WriteStartDocument(true);
            }
            catch (System.Exception ex)
            { My.Box.Info(ex.Message + "\n\n My::Xml::NewFile()"); }
            return xw;
        }

        public static string GetAttributeValue(XmlDocument doc, string element, string attr)
        {
            XmlNodeList list = doc.GetElementsByTagName(element);
            if (list.Count > 0)
            {
                XmlNode node = list.Item(0);
                XmlAttribute att = node.Attributes[attr];
                if (att != null) return att.Value.ToString();
            }
            return "";
        }

        public static string GetValue(XmlDocument doc, string element)
        {
            XmlNodeList list = doc.GetElementsByTagName(element);
            if (list.Count > 0)
            {
                XmlNode node = list.Item(0);
                XmlAttribute att = node.Attributes["value"];
                if (att != null) return att.Value.ToString();
            }
            return "";
        }

        public static void WriteElementAttribute(XmlTextWriter xw, string elem, string att, string val)
        {
            xw.WriteStartElement(elem);
            xw.WriteAttributeString(att, val);
            xw.WriteEndElement();
        }

        public static string Filter(string s)
        {
            string result = s.Replace("\r\n", "").TrimStart(null).TrimEnd(null);
            while (result.IndexOf("  ") != -1) result = result.Replace("  ", " ");
            return result;
        }

        public static void Write(XmlTextWriter xw, string elem, string val)
        {
            xw.WriteStartElement(elem);
            xw.WriteAttributeString("value", val);
            xw.WriteEndElement();
        }
    }
}
