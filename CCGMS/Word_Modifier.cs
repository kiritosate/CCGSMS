﻿using CCGMS.view;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCGMS.docs
{
    internal class Word_Modifier
    {
        // Method to modify the Word document template and save it to a new file
        private void ModifyWordDocument(string filePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
            {
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;

                // Dictionary of placeholders and their values
                var replacements = new Dictionary<string, string>
        {
            { "id_no", "KiritoSate" },
            { "course_year", "BSIT 4" },
            { "O_1", "0" },
            { "O_2", "1" },
            { "O_3", "1" },
            { "O_4", "1" }
        };

                // Replace all placeholders in the document
                foreach (var item in replacements)
                {
                    string replacementValue = item.Key.StartsWith("O_") && item.Value == "1" ? "[✓]" : "[ ]";
                    ReplacePlaceholderSeamlessly(mainPart.Document.Body, item.Key, item.Key.StartsWith("O_") ? replacementValue : item.Value);
                }

                // Save the document
                mainPart.Document.Save();
            }
        }

        private void ReplacePlaceholderSeamlessly(Body documentBody, string placeholder, string replacementValue)
        {
            // Collect runs that contribute to the placeholder
            var runs = new List<Run>();
            StringBuilder combinedText = new StringBuilder();
            bool foundPlaceholder = false;

            foreach (var paragraph in documentBody.Descendants<Paragraph>())
            {
                foreach (var run in paragraph.Descendants<Run>())
                {
                    foreach (var text in run.Descendants<Text>())
                    {
                        combinedText.Append(text.Text);
                        runs.Add(run);

                        // Check if combined text contains the placeholder
                        if (combinedText.ToString().Contains(placeholder))
                        {
                            foundPlaceholder = true;
                            break;
                        }
                    }

                    if (foundPlaceholder)
                    {
                        break;
                    }
                }

                if (foundPlaceholder)
                {
                    // Replace the placeholder
                    string newText = combinedText.ToString().Replace(placeholder, replacementValue);

                    // Clear the text in the existing runs
                    foreach (var run in runs)
                    {
                        foreach (var text in run.Descendants<Text>())
                        {
                            text.Text = string.Empty;
                        }
                    }

                    // Redistribute the new text across the runs or add a new run if needed
                    int currentIndex = 0;
                    foreach (var run in runs)
                    {
                        var textElement = run.GetFirstChild<Text>();
                        if (textElement != null && currentIndex < newText.Length)
                        {
                            int length = Math.Min(newText.Length - currentIndex, textElement.Text.Length);
                            textElement.Text = newText.Substring(currentIndex, length);
                            currentIndex += length;
                        }
                    }

                    // If the replacement text is longer than the original placeholder, append the extra text to the last run
                    if (currentIndex < newText.Length)
                    {
                        var lastRun = runs.Last();
                        lastRun.Append(new Text(newText.Substring(currentIndex)));
                    }

                    break;
                }
            }
        }


        private void ReplacePlaceholder(Body documentBody, string placeholder, string replacementValue)
        {
            // Iterate through all paragraphs in the document
            foreach (var paragraph in documentBody.Descendants<Paragraph>())
            {
                StringBuilder combinedText = new StringBuilder();
                List<Text> textElements = new List<Text>();

                // Collect all text elements and combine their text content
                foreach (var run in paragraph.Descendants<Run>())
                {
                    foreach (var text in run.Descendants<Text>())
                    {
                        combinedText.Append(text.Text);
                        textElements.Add(text); // Keep track of the text elements
                    }
                }

                // Check if the combined text contains the placeholder
                if (combinedText.ToString().Contains(placeholder))
                {
                    // Replace the placeholder in the combined text
                    string newCombinedText = combinedText.ToString().Replace(placeholder, replacementValue);

                    // Redistribute the new combined text back into the original text elements
                    int currentIndex = 0;

                    foreach (var text in textElements)
                    {
                        // Determine the length of the current text element
                        int textLength = text.Text.Length;

                        // Check if there's enough remaining text to fill this element
                        if (currentIndex + textLength <= newCombinedText.Length)
                        {
                            text.Text = newCombinedText.Substring(currentIndex, textLength);
                            currentIndex += textLength;
                        }
                        else
                        {
                            // If the remaining text is less than the length of the element, fill it with the rest
                            text.Text = newCombinedText.Substring(currentIndex);
                            break; // Stop when all the new text is applied
                        }
                    }
                }
            }
        }

        public void ModifyAndPrintDocument()
        {
            // Get the current directory where the executable or project is running
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Path to the original template
            string templatePath = Path.Combine(currentDirectory, "docs", "f1.docx");

            // Path to save the modified Word document
            string outputPath = Path.Combine(currentDirectory, "docs", "modified.docx");
            // Copy template to new file
            File.Copy(templatePath, outputPath, true);

            // Modify the document
            ModifyWordDocument(outputPath);

            // Print the modified document silently
            PrintWordDocument(outputPath);
        }

        // Method to print the Word document
        public void PrintWordDocument(string filePath)
        {
            // Use Process.Start to send the file to the default printer silently
            ProcessStartInfo info = new ProcessStartInfo(filePath)
            {
                Verb = "Print",
                CreateNoWindow = true, // Don't show any window
                WindowStyle = ProcessWindowStyle.Hidden // Make sure it's hidden
            };

            try
            {
                // Start the process to print the document
                Process.Start(info);
            }
            catch (Exception ex)
            {
                // Handle printing errors (e.g., if no default printer is set)
                Console.WriteLine("Error printing document: " + ex.Message);
            }
        }
    }
}