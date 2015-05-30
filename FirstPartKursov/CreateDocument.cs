using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using iTextSharp.text;
using iTextSharp;
using System.IO;
using iTextSharp.text.pdf;
using AODL;
using AODL.Document;
using AODL.Document.TextDocuments;
using AODL.Document.SpreadsheetDocuments;
using AODL.Document.Content.Tables;
using AODL.Document.Styles;
using AODL.Document.Content.Text;

namespace FirstPartKursov
{
    class CreateDocument
    {
        /// <summary>
        /// документ - заявка
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="filialAddress"></param>
        /// <param name="nameProvider"></param>
        public void createDocument_order(List<string> goods, string filialAddress, string nameProvider)
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(ClassForms.sf.filePath.filepathUser + "Документы на заказ товаров\\" + "Document_Order." + DateTime.Now.ToShortDateString() + ".pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Phrase phraseNameShop = new Phrase("Магазин музыкальных инструментов \"Анастасия\"", new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.ITALIC, new BaseColor(Color.Black)));
            iTextSharp.text.Phrase phraseAddressOffice = new Phrase("Россия, г. Ульяновск, Ленинский район, улица Гончарова дом 5, 432002", new iTextSharp.text.Font(baseFont, 8, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Phrase phraseContacts = new Phrase("тел.:639-235, email: ofis_tsentralnyy@mail.ru", new iTextSharp.text.Font(baseFont, 8, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Phrase phraseTitle = new Phrase("Заказ", new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Phrase phraseProvider = new Phrase("Кому: " + nameProvider, new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
           
            iTextSharp.text.Phrase phraseWayOfGet = new Phrase("Средство доставки: Курьер", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Phrase phraseAmountAndGet = new Phrase("Счет и доставка в: филиал магазина музыкальных инструментов \"Анастасия\": " + filialAddress, new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
            
            iTextSharp.text.Phrase phraseDate = new Phrase("Дата заказа: ", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Phrase phraseSignProvider = new Phrase("Поставщик: _____________________________ Заказчик___________________________", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
           
            iTextSharp.text.Paragraph paragraph1 = new iTextSharp.text.Paragraph(phraseNameShop);
            paragraph1.Alignment = Element.ALIGN_RIGHT;
            iTextSharp.text.Paragraph paragraph2 = new iTextSharp.text.Paragraph(phraseAddressOffice);
            paragraph2.Alignment = Element.ALIGN_RIGHT;
            iTextSharp.text.Paragraph paragraph3 = new iTextSharp.text.Paragraph(phraseContacts);
            paragraph3.Alignment = Element.ALIGN_RIGHT;
            iTextSharp.text.Paragraph paragraph4 = new iTextSharp.text.Paragraph(phraseTitle);
            paragraph4.Alignment = Element.ALIGN_CENTER;
            iTextSharp.text.Paragraph paragraph5 = new iTextSharp.text.Paragraph(phraseProvider);
            iTextSharp.text.Paragraph paragraph7 = new iTextSharp.text.Paragraph(phraseWayOfGet);
            iTextSharp.text.Paragraph paragraph8 = new iTextSharp.text.Paragraph(phraseAmountAndGet);
            iTextSharp.text.Paragraph paragraph9 = new iTextSharp.text.Paragraph(phraseDate);
            paragraph9.Alignment = Element.ALIGN_BOTTOM;
            iTextSharp.text.Paragraph paragraph10 = new iTextSharp.text.Paragraph(phraseSignProvider);
            paragraph10.Alignment = Element.ALIGN_RIGHT;
        
           
            doc.Add(paragraph1);
            doc.Add(paragraph2);
            doc.Add(paragraph3);
            doc.Add(paragraph4);
            doc.Add(paragraph5);
            doc.Add(paragraph7);
            doc.Add(paragraph8);

            PdfPTable table = new PdfPTable(6);

            PdfPCell cell = new PdfPCell(new Phrase("№", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            PdfPCell cellName = new PdfPCell(new Phrase("Наименование товара", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellName.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellName);

            PdfPCell cellCurrency = new PdfPCell(new Phrase("Валюта", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellCurrency.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellCurrency);

            PdfPCell cellPrice = new PdfPCell(new Phrase("Цена", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellPrice.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellPrice);

            PdfPCell cellAmount = new PdfPCell(new Phrase("Количество, шт", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellAmount.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellAmount);

            PdfPCell cellGeneralPrice = new PdfPCell(new Phrase("Стоимость, руб", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellGeneralPrice.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellGeneralPrice);

            PdfPCell cellNumber;
            PdfPCell cellNameGood;
            PdfPCell cellCurrencyGood;
            PdfPCell cellPriceGood;
            PdfPCell cellAmountGood;
            PdfPCell cellGeneralPriceGood;
            double generalAmount=0;
            double generalgeneralAmount = 0;
            for (int i = 0; i < goods.Count; i++)
            {
                generalAmount = 0;
                cellNumber = new PdfPCell(new Phrase((i + 1).ToString(), new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellNumber.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellNumber);
                cellNameGood = new PdfPCell(new Phrase(goods[i].Split('|')[0], new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellNameGood.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellNameGood);
                cellCurrencyGood = new PdfPCell(new Phrase(goods[i].Split('|')[1], new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellCurrencyGood.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellCurrencyGood);
                cellPriceGood = new PdfPCell(new Phrase(goods[i].Split('|')[2], new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellPriceGood.HorizontalAlignment = Element.ALIGN_CENTER;
                if (goods[i].Split('|')[1].ToString().ToUpper().Equals("RUB"))
                {
                    generalAmount += Convert.ToInt32(goods[i].Split('|')[2]);
                }
                else if (goods[i].Split('|')[1].ToString().ToUpper().Equals("EUR"))
                {
                    generalAmount += Convert.ToInt32(goods[i].Split('|')[2]) * Valuta.euro;
                }
                else if (goods[i].Split('|')[1].ToString().ToUpper().Equals("USD"))
                {
                    generalAmount += Convert.ToInt32(goods[i].Split('|')[2]) * Valuta.usd;
                }
                table.AddCell(cellPriceGood);
                cellAmountGood = new PdfPCell(new Phrase("15", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellAmountGood.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellAmountGood);
                generalAmount = generalAmount * 15;
                cellGeneralPriceGood = new PdfPCell(new Phrase(generalAmount.ToString(), new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellGeneralPriceGood.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellGeneralPriceGood);
                generalgeneralAmount += generalAmount;
            }
            table.SpacingBefore = 15;
            doc.Add(table);
            iTextSharp.text.Phrase phraseGeneralAmount = new Phrase("Общая стоимость заказа: " + generalgeneralAmount.ToString(), new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Paragraph paragraph11 = new iTextSharp.text.Paragraph(phraseGeneralAmount);
            doc.Add(paragraph11);
            doc.Add(paragraph9);
            doc.Add(paragraph10);
            ClassForms.sf.label1.Text += Environment.NewLine + "Сформирован и отправлен документ-заявки на товар от: " + DateTime.Now.ToShortDateString() +  "." + " Кому: " + nameProvider;
            ClassForms.sf.label1.Refresh();
            doc.Close();
        }

        /// <summary>
        /// документ - приказ
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="oldFilialAddress"></param>
        /// <param name="newFilialAddress"></param>
        public void createDocument_Command(List<string> goods, string oldFilialAddress, string newFilialAddress)
        {


            TextDocument document_Command = new TextDocument();
            document_Command.New();

           
            AODL.Document.Content.Text.Paragraph paragraphNameShop = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphNameShop.TextContent.Add(new SimpleText(document_Command, "Магазин музыкальных инструментов \"Анастасия\""));
            paragraphNameShop.ParagraphStyle = new ParagraphStyle(document_Command, "Style");
            paragraphNameShop.ParagraphStyle.ParagraphProperties.Alignment = AODL.Document.Styles.Properties.TextAlignments.right.ToString();
            document_Command.Content.Add(paragraphNameShop);
            

            AODL.Document.Content.Text.Paragraph paragraphDate = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphDate.TextContent.Add(new SimpleText(document_Command, DateTime.Now.ToShortDateString()));
            document_Command.Content.Add(paragraphDate);

            AODL.Document.Content.Text.Paragraph paragraphTitle = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphTitle.TextContent.Add(new SimpleText(document_Command, "ПРИКАЗ"));
            document_Command.Content.Add(paragraphTitle);

            AODL.Document.Content.Text.Paragraph paragraphCity = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphCity.TextContent.Add(new SimpleText(document_Command, "Ульяновск"));
            document_Command.Content.Add(paragraphCity);

            AODL.Document.Content.Text.Paragraph paragraphCommandAbout = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphCommandAbout.TextContent.Add(new SimpleText(document_Command, "Начальнику склада о перемещении товаров"));
            document_Command.Content.Add(paragraphCommandAbout);

            AODL.Document.Content.Text.Paragraph paragraphPurpose = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphPurpose.TextContent.Add(new SimpleText(document_Command, "С целью обеспечения других филиалов недостающими товарами, руководствуясь подпунктом 10.2 пункта 10 Приказ генерального директора магазина музыкальных инструментов \"Анастасия\" от 02.03.2005 г. \"О распределении товаров по филиалам\","));
            document_Command.Content.Add(paragraphPurpose);

            AODL.Document.Content.Text.Paragraph paragraphCommand = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphCommand.TextContent.Add(new SimpleText(document_Command, "ПРИКАЗЫВАЮ:"));
            document_Command.Content.Add(paragraphCommand);

            AODL.Document.Content.Text.Paragraph paragraphFirst = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphFirst.TextContent.Add(new SimpleText(document_Command, "1. Перераспределить нижепреведенный список товаров на склад филиала по адресу: " + newFilialAddress + "со склада филиала по адресу: " + oldFilialAddress + ", в связи с необходимостью."));
            document_Command.Content.Add(paragraphFirst);



            AODL.Document.Content.Text.Paragraph newParagraph;
            for (int i = 0; i < goods.Count; i++)
            {

                newParagraph = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
                newParagraph.TextContent.Add(new SimpleText(document_Command, "1." + (i + 1).ToString() + ". " + goods[i].Split('|')[0] + ". Количество: " + goods[i].Split('|')[2] + " шт."));
                document_Command.Content.Add(newParagraph);
                
            }




            AODL.Document.Content.Text.Paragraph paragraphSecond = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphSecond.TextContent.Add(new SimpleText(document_Command, "2. Поручить начальнику склада оформить отчет о доставке перемещаемых товаров в срок."));
            document_Command.Content.Add(paragraphSecond);

            AODL.Document.Content.Text.Paragraph paragraphThird = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphThird.TextContent.Add(new SimpleText(document_Command, "3. Контроль за исполнение настоящего приказа оставляю за собой."));
            document_Command.Content.Add(paragraphThird);

            AODL.Document.Content.Text.Paragraph paragraphBoss = ParagraphBuilder.CreateStandardTextParagraph(document_Command);
            paragraphBoss.TextContent.Add(new SimpleText(document_Command, "Генеральный директор: _____________________________ Щербакова А.А."));
            document_Command.Content.Add(paragraphBoss);
            ClassForms.sf.label1.Text += Environment.NewLine + "Сформирован и отправлен приказ генеральному директору о перераспределении товаров от: " + DateTime.Now.ToShortDateString() + ".";
            ClassForms.sf.label1.Refresh();
            document_Command.SaveTo(ClassForms.sf.filePath.filepathUser + "Документы на перераспределение товаров\\" + "Document_Command." + DateTime.Now.ToShortDateString() + ".odt");

        }
        /// <summary>
        /// документ - накладная
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="numberStorage"></param>
        public void createDocument_Invoice(List<string> goods, int numberStorage)
        {
           

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(ClassForms.sf.filePath.filepathUser + "Документы на перераспределение товаров\\" + "Document_Invoice." + DateTime.Now.ToShortDateString() + ".pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Phrase phraseDate = new Phrase("от "+DateTime.Now.ToShortDateString(), new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            iTextSharp.text.Phrase phraseTitle = new Phrase("НАКЛАДНАЯ", new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Phrase phraseWhom = new Phrase("Кому: Начальнику склада № " + numberStorage.ToString(), new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Phrase phraseBossFrom = new Phrase("От кого: Генерального директора Щербаковой А.А.", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Phrase phraseGive = new Phrase("Сдал: ___________________________________________", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Phrase phraseGet = new Phrase("Принял: ____________________________________________", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL));
          
            

            iTextSharp.text.Paragraph paragraphDate = new iTextSharp.text.Paragraph(phraseDate);
            paragraphDate.Alignment = Element.ALIGN_LEFT;
            iTextSharp.text.Paragraph paragraphTitle = new iTextSharp.text.Paragraph(phraseTitle);
            paragraphTitle.Alignment = Element.ALIGN_CENTER;
            iTextSharp.text.Paragraph paragraphWhom = new iTextSharp.text.Paragraph(phraseWhom);
            iTextSharp.text.Paragraph paragraphBossFrom = new iTextSharp.text.Paragraph(phraseBossFrom);
            paragraphBossFrom.SpacingAfter = 4;
            iTextSharp.text.Paragraph paragraphGive = new iTextSharp.text.Paragraph(phraseGive);
            paragraphGive.SpacingBefore = 2;
            iTextSharp.text.Paragraph paragraphGet = new iTextSharp.text.Paragraph(phraseGet);
            paragraphGet.SpacingBefore = 2;
            

            doc.Add(paragraphDate);
            doc.Add(paragraphTitle);
            doc.Add(paragraphWhom);
            doc.Add(paragraphBossFrom);


            PdfPTable table = new PdfPTable(7);

            PdfPCell cell = new PdfPCell(new Phrase("№", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            PdfPCell cellName = new PdfPCell(new Phrase("Наименование товара", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellName.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellName);

            PdfPCell cellEI = new PdfPCell(new Phrase("Ед. изм.", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellEI.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellEI);

            PdfPCell cellAmount = new PdfPCell(new Phrase("Кол-во товара", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellAmount.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellAmount);

            PdfPCell cellPrice = new PdfPCell(new Phrase("Валюта", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellPrice.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellPrice);

            PdfPCell cellPriceAmount = new PdfPCell(new Phrase("Цена", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellPriceAmount.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellPriceAmount);

            PdfPCell cellPriceGeneral = new PdfPCell(new Phrase("Сумма", new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
            cellPriceGeneral.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellPriceGeneral);

            PdfPCell cellNumber;
            PdfPCell cellNameGood;
            PdfPCell cellEIGood;
            PdfPCell cellAmountGood;
            PdfPCell cellPriceGood;
            PdfPCell cellValuta;
            PdfPCell cellPriceAmountGood;

            for (int i = 0; i < goods.Count; i++)
            {
                cellNumber = new PdfPCell(new Phrase((i + 1).ToString(), new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellNumber.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellNumber);
                cellNameGood = new PdfPCell(new Phrase(goods[i].Split('|')[0], new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellNameGood.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellNameGood);
                cellEIGood = new PdfPCell(new Phrase(goods[i].Split('|')[1], new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellEIGood.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellEIGood);
                cellAmountGood = new PdfPCell(new Phrase(goods[i].Split('|')[2], new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellAmountGood.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellAmountGood);
                cellValuta = new PdfPCell(new Phrase(goods[i].Split('|')[3], new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellValuta.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellValuta);
                cellPriceGood = new PdfPCell(new Phrase(goods[i].Split('|')[4], new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellPriceGood.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellPriceGood);
                cellPriceAmountGood = new PdfPCell(new Phrase((Convert.ToInt32(goods[i].Split('|')[2])*Convert.ToInt32(goods[i].Split('|')[4])).ToString(), new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL)));
                cellPriceAmountGood.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellPriceAmountGood);
            }
            table.SpacingBefore = 15;
            doc.Add(table);
            doc.Add(paragraphGive);
            doc.Add(paragraphGet);

            ClassForms.sf.label1.Text += Environment.NewLine + "Сформирована и отправлена накладная с товарами на распределение от: " + DateTime.Now.ToShortDateString() + "." + " В склад №: " + numberStorage.ToString();
            ClassForms.sf.label1.Refresh();
            doc.Close();


        }
    }
}
