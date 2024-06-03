using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class CsvFileManager
{
    private string _filePath;

    public CsvFileManager(string filePath)
    {
        _filePath = filePath;
    }

    public void WriteRecords<T>(IEnumerable<T> records)
    {
        using (var writer = new StreamWriter(_filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(records);
        }
    }

    public void ResetFile()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void DeleteRecordById<T>(int id) where T : class
    {
        var records = ReadRecords<T>().ToList();
        var recordToRemove = records.FirstOrDefault(r => ((dynamic)r).Id == id);
        if (recordToRemove != null)
        {
            records.Remove(recordToRemove);
            WriteRecords(records);
        }
    }

    public void UpdateRecord<T>(int id, T updatedRecord) where T : class
    {
        DeleteRecordById<T>(id);
        AddRecord(updatedRecord);
    }

    public IEnumerable<T> ReadRecords<T>() where T : class
    {
        using (var reader = new StreamReader(_filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<T>().ToList();
        }
    }

    private void AddRecord<T>(T record) where T : class
    {
        var records = ReadRecords<T>().ToList();
        records.Add(record);
        WriteRecords(records);
    }
}

public class CsvRecord
{
    [Name("ID")]
    public int Id { get; set; }

    [Name("NomSauvegarde")]
    public string NomSauvegarde { get; set; }

    [Name("NiveauActuel")]
    public int NiveauActuel { get; set; }

    [Name("ModeJeu")]
    public string ModeJeu { get; set; }

    [Name("Difficulte")]
    public string Difficulte { get; set; }

    [Name("Score")]
    public int Score { get; set; }

    [Name("MatriceLabyrinthe")]
    public string MatriceLabyrinthe { get; set; }

    [Name("PseudoJoueur")]
    public string PseudoJoueur { get; set; }

    [Name("NombreVies")]
    public int NombreVies { get; set; }

    [Name("NombreCoeurs")]
    public int NombreCoeurs { get; set; }
}
