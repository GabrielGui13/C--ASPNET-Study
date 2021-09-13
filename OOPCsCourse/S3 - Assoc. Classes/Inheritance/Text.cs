using System;

public class Text : PresentationObject {
	public int FontSize { get; set; }
	public int FontName { get; set; }

	public void AddHyperLink(string url) {
		Console.WriteLine("Added link to " + url);
	}
}