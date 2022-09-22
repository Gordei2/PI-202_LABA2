using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    internal static class FromXmlToList
    {
        public static string ToStringList(string filepath, AParse parser)
        {
            AFields store;
            try
            {
                store = parser.FormatParse(filepath);
                return store.ToString();
            } catch (NullReferenceException)
            {
                MessageBox.Show("No file found or incorrect file filling", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception)
            {
                MessageBox.Show("Incorrect data format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "";
        }
    }
}
