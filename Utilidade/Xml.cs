namespace Utilidade
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Xml;

    public class Xml
    {
        private XmlDocument xmldoc;
        private XmlNode xmlnode;
        private string _xmlpath;
        
        public string XmlPath
        {
            get { return _xmlpath; }
            set { _xmlpath = value; }
        }
        
        public Xml() { }

        public XmlDocument GerarXML(DataTable tabela)
        {
            string parametros;

            xmldoc = new XmlDocument();
            xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);

            parametros = ((tabela.TableName.ToString() == null) ? "TABELA" : tabela.TableName.ToString().ToUpper());

            xmlnode = xmldoc.CreateElement(parametros.ToUpper());
            xmldoc.AppendChild(xmlnode);
            
            foreach (DataRow linha in tabela.Rows)
            {
                //xmlnode = xmldoc.CreateElement(parametros + "REGISTRO");
                xmlnode = xmldoc.CreateElement("REGISTRO");

                for (int i = 0; i < linha.Table.Columns.Count; i++)
                {
                    XmlNode xmlnode_parente = xmldoc.CreateElement(linha.Table.Columns[i].ColumnName.ToString().ToUpper(),
                                                                   linha.Table.Columns[i].ColumnName.ToString().ToUpper(),
                                                                   null);
                    xmlnode_parente.InnerText = linha[i].ToString();
                    xmlnode.AppendChild(xmlnode_parente);
                    xmldoc.SelectSingleNode("/" + parametros.ToUpper() + "").AppendChild(xmlnode);
                }
            }

            //LimparDocumento();
            return xmldoc;
        }
    }
}