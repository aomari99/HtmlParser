using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
	public enum View
	{
		body, div, a, h, p, img, video, ul, span, li, h1, h2, h3, tab, nav, input, button, form, section, label, article, style, b, code, iframe, script, option, path, svg, ol, em, unknown
	};



	public class Element
	{

		private string seperator_src = "src=\"";
		private string seperator_id = "id=\"";
		private string seperator_class = "class=\"";
		private string seperator_href = "href=\"";
		private bool src_split = false;
		private bool id_split = false;
		private bool class_split = false;
		private bool href_split = false;
		private string src = "";
		private string id = "";
		private string classname = "";
		private string href = "";
		private string title = "";
		private int srcpos = 0;
		private int idpos = 0;
		private int classpos = 0;
		private int hrefpos = 0;
		private bool typedone = false;
		public int pos = -1;

		public string content = "";
		public string header;
		public int dispostufe;
		public int parent;
		public View type = new View();
		public List<Element> children = new List<Element>();


		public string getCustomHeader(string item)
        {
			int custompos = 0;
			bool custombool = false;
			for (int i = 1; i < header.Length; i++)
			{
				if (header[i] == item[0] && (i + item.Length) < header.Length)
				{
					try
					{
						if (header.Substring(i, item.Length) == item)
						{
							custompos = i + item.Length;
							i = custompos;
							custombool = true;
						}
					}
					catch (Exception ex) { }
				}

				if (custombool && header[i] == '\"')
				{

					return header.Substring(custompos, i - custompos);
					 
				}
			}

			return "";
			}

		public Element(string _header, int _dispo, int _parent, int _pos)
		{
			header = _header;
			dispostufe = _dispo;
			parent = _parent;
			pos = _pos;





			for (int i = 1; i < header.Length; i++)
			{
				if (!typedone && (header[i] == ' ' || header[i] == '>'))
				{
					var typestr = header.Substring(1, i - 1);

					type = hashit(typestr);

					typedone = true;
				}
				//src
				if (header[i] == seperator_src[0] && (i + seperator_src.Length) < header.Length)
				{
					try
					{
						if (header.Substring(i, seperator_src.Length) == seperator_src)
						{
							srcpos = i + seperator_src.Length;
							i = srcpos;
							src_split = true;
						}
					}
					catch (Exception ex) { }
				}

				if (src_split && header[i] == '\"')
				{

					src = header.Substring(srcpos, i - srcpos);
					src_split = false;
				}
				//id

				if (header[i] == seperator_id[0] && (i + seperator_id.Length) < header.Length)
				{
					try
					{
						if (header.Substring(i, seperator_id.Length) == seperator_id)
						{
							idpos = i + seperator_id.Length;
							i = idpos;
							id_split = true;
						}
					}
					catch (Exception ex) { }
				}

				if (id_split && header[i] == '\"')
				{

					id = header.Substring(idpos, i - idpos);
					id_split = false;
				}


				//class
				if (header[i] == seperator_class[0] && (i + seperator_class.Length) < header.Length)
				{
					try
					{
						if (header.Substring(i, seperator_class.Length) == seperator_class)
						{
							classpos = i + seperator_class.Length;
							i = classpos;
							class_split = true;
						}
					}
					catch (Exception ex) { }
				}

				if (class_split && header[i] == '\"')
				{

					classname = header.Substring(classpos, i - classpos);
					class_split = false;
				}
				//href
				 if(header[i] == seperator_href[0] && (i + seperator_href.Length) < header.Length){
						if(header.Substring(i,seperator_href.Length) == seperator_href){
							hrefpos = i + seperator_href.Length;
							i = hrefpos ;
							href_split = true ;
						}
					}

					if(href_split && header[i] == '\"'){

							href = header.Substring(hrefpos, i - hrefpos);
							href_split = false ;
					} 
			}
		}
		public Element()
		{
		}

		public List<Element> getChildren()
		{

			return new List<Element>(children);


		}

		public Element getChild()
		{

			return children.Count == 0 ? null : children[0];
		}

		public string getSrc()
		{
			return src;
		}

		public string getClass()
		{
			return classname;
		}

		public string getId()
		{
			return id;
		}


		public string getHref()
		{
			return href;
		}

		public View hashit(string inString)
		{
			if (inString == "div")
			{
				return View.div;
			}
			if (inString == "body")
			{
				return View.body;
			}
			if (inString == "a")
			{
				return View.a;
			}
			if (inString == "h")
			{
				return View.h;
			}
			if (inString == "p")
			{
				return View.p;
			}
			if (inString == "img")
			{
				return View.img;
			}
			if (inString == "video")
			{
				return View.video;
			}
			if (inString == "li")
			{
				return View.li;
			}
			if (inString == "ul")
			{
				return View.ul;
			}
			if (inString == "span")
			{
				return View.span;
			}
			if (inString == "h2")
			{
				return View.h2;
			}
			if (inString == "h3")
			{
				return View.h3;
			}
			if (inString == "tab")
			{
				return View.tab;
			}
			if (inString == "nav")
			{
				return View.nav;
			}
			if (inString == "input")
			{
				return View.input;
			}
			if (inString == "button")
			{
				return View.button;
			}
			if (inString == "form")
			{
				return View.form;
			}
			if (inString == "section")
			{
				return View.section;
			}
			if (inString == "label")
			{
				return View.label;
			}
			if (inString == "article")
			{
				return View.article;
			}
			if (inString == "style")
			{
				return View.style;
			}
			if (inString == "b")
			{
				return View.b;
			}
			if (inString == "code")
			{
				return View.code;
			}
			if (inString == "iframe")
			{
				return View.iframe;
			}
			if (inString == "script")
			{
				return View.script;
			}
			if (inString == "option")
			{
				return View.option;
			}
			if (inString == "path")
			{
				return View.path;
			}
			if (inString == "svg")
			{
				return View.svg;
			}
			if (inString == "ol")
			{
				return View.ol;
			}
			if (inString == "em")
			{
				return View.em;
			}
			if (inString == "h1")
			{
				return View.h1;
			}
			return View.unknown;
		}

	}


	public class HtmlParser
	{
		public List<Element> Elements;


		public async Task<List<Element>> setup(string url)
		{

			string html = new WebClient().DownloadString(url);
			Console.WriteLine(html);
			Elements = parse(html, "<", "</", ">", "/>");
			return Elements;
		}

		public async Task<List<Element>> setup_HTML(string html)
		{

		 
			Console.WriteLine(html);
			Elements = parse(html, "<", "</", ">", "/>");
			return Elements;
		}

		private List<Element> parse(string data, string begin, string seperator1, string seperator2, string seperator3)
		{


			string[] whitelist = { "!", "img", "input", "meta", "link", "br", "area", "base", "col", "command", "embed", "hr", "keygen", "param", "source", "track", "wbr", "!Doctype" };

			int len1 = seperator1.Length;
			int len2 = seperator2.Length;
			int len3 = seperator3.Length;
			int beginlen = begin.Length;
			List<Element> output = new List<Element>();
			bool sep = false;
			int counter = -1;
			int lastpos = 0;
			List<int> lastpositions = new List<int>();
			List<int> itempos = new List<int>();
			bool ignore = false;

			int seppos = -1;


			//	std::vector<int>  hendpositions;

			for (int i = 0; i < data.Length; i++)
			{

				if (!ignore && data[i] == begin[0])
				{
					if (data.Substring(i, beginlen) == begin && data.Substring(i, len1) != seperator1)
					{
						lastpositions.Add(i);
						counter++;

					}
				}

				if (lastpositions.Count > 0 && !ignore && sep == false && data[i] == seperator2[0])
				{
					if (data.Substring(i, len2) == seperator2)
					{
						int pos = (i + len2);
						//		hendpositions.push_back(i);
						lastpos = lastpositions[lastpositions.Count - 1];

						int parentid = -1;
						int position = output.Count;
						if (position > 0)
						{
							var lastitem = output[output.Count - 1];
							parentid = (lastitem.dispostufe == counter) ? lastitem.parent : parentid;
							parentid = (lastitem.dispostufe < counter) ? output.Count - 1 : parentid;
							while (lastitem.dispostufe > counter)
							{
								lastitem = output[lastitem.parent];
								parentid = lastitem.parent;

							}


						}


						output.Add(new Element(data.Substring(lastpos, pos - lastpos), counter, parentid, position));

						if (parentid != -1)
						{
							output[parentid].children.Add(output[position]);
						}

						lastpositions[lastpositions.Count - 1] = i + 1;
						itempos.Add(output.Count - 1);
						foreach (string item in whitelist)
						{
							if (data.Substring(lastpos + 1, item.Length) == item)
							{
								/*	lastpos = lastpositions.back() ;
									lastpositions.pop_back() ;
										counter--;*/
								sep = true;
							}

						}

						string igno = "script";
						if (data.Substring(lastpos + 1, igno.Length) == igno)
						{
							ignore = true;
						}

					}
				}

				if (sep && data[i] == seperator2[0])
				{
					if (data.Substring(i, len2) == seperator2)
					{

						/*	if(counter > 1){
								counter--;
								sep = false ;
								 continue;
							}*/

						int pos = i; //(i + len2);
						lastpos = lastpositions[lastpositions.Count - 1];
						lastpositions.RemoveAt(lastpositions.Count - 1);
						if (seppos > lastpos)
						{
							var stri = data.Substring(lastpos, seppos - lastpos);
							var itempos1 = itempos[itempos.Count - 1];
							itempos.RemoveAt(itempos.Count - 1);

							output[itempos1].content = (stri);
						}
						else
						{
							var itempos1 = itempos[itempos.Count - 1];
							itempos.RemoveAt(itempos.Count - 1);
						}
						//		std::cout << lastpos << "::" << pos << " Output: " << stri << std::endl;




						ignore = false;
						lastpos = pos + 1;
						counter--;
						sep = false;
					}
				}


				if (data[i] == seperator3[0])
				{
					if (data.Substring(i, len3) == seperator3)
					{
						/*		if(counter > 1){
									counter--;
									sep = false ;
									 continue;
								}*/

						lastpos = lastpositions[lastpositions.Count - 1];
						lastpositions.RemoveAt(lastpositions.Count - 1);
						//	int pos = (i + len3);
						int pos = i;
						var stri = data.Substring(lastpos, pos - lastpos);

						//std::cout << lastpos << "::" << pos << " Output: " << stri << std::endl;


						var itempos1 = itempos[itempos.Count - 1];
						itempos.RemoveAt(itempos.Count - 1);

						//		output[itempos1].content = (stri);	


						ignore = false;
						lastpos = pos + 1;
						counter--;
						sep = false;
					}
				}

				if (counter >= 0 && data[i] == seperator1[0])
				{
					if (data.Substring(i, len1) == seperator1)
					{ //first char equals
						sep = true;
						seppos = i;
					}
				}
			}
			Console.Write("Counter: ");
			Console.Write(counter);
			Console.Write("\n");
			Console.Write("itempos: ");
			Console.Write(itempos.Count);
			Console.Write("\n");
			return new List<Element>(output);
		}
	}
}
