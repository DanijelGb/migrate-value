using System.Xml.Linq;

XElement doc = XElement.Load("../../../sma_gentext.xml");

IEnumerable<XElement> solution =
    from el in doc.Element("file")?.Elements("body").Elements("trans-unit")
    where (string?)el.Attribute("id") == "42007"
    select el.Element("target");

string path = "../../../target.txt";

foreach (XElement el in solution)
{
    File.WriteAllText(path, el.Value);
}
