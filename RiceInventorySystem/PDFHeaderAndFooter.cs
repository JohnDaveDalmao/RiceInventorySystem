using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiceInventorySystem {
    class HeaderAndFooter : PdfPageEventHelper {
        public override void OnEndPage(PdfWriter writer, Document document) {
            //base.OnEndPage(writer, document);
            PdfPTable tbHeader = new PdfPTable(3);
            tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tbHeader.WidthPercentage = 100;
            tbHeader.DefaultCell.Border = 0;
            tbHeader.AddCell(new Paragraph());

            var FontStyle = FontFactory.GetFont("Arial Rounded MT", 14, new BaseColor(55, 71, 79));
            FontStyle.SetStyle(1);

            PdfPCell cell = new PdfPCell(new Paragraph(new Chunk("F U L L  S U M M A R Y", FontStyle)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;

            tbHeader.AddCell(cell);
            tbHeader.AddCell(new Paragraph());

            tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 30, writer.DirectContent);

            PdfPTable tbFooter = new PdfPTable(3);
            tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tbFooter.DefaultCell.Border = 0;
            tbFooter.AddCell(new Paragraph());

            cell = new PdfPCell(new Paragraph("John Dave Dalmao"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;

            tbFooter.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Page " + writer.PageNumber));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;

            tbFooter.AddCell(cell);

            tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin), writer.DirectContent);
        }
    }
}
