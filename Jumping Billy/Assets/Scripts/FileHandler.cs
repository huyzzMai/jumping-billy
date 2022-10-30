using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;
using Directory = System.IO.Directory;
using File = System.IO.File;
using Input = UnityEngine.Input;

public class FileHandler : Singleton<FileHandler>
{
    private const string processFile = "process.txt";
    private const string highscoreFile = "highscore.txt";
    string directory;

    private void Awake()
    {
        checkFilePath();
    }
    public void checkFilePath()
    {
        directory = Application.dataPath + Path.AltDirectorySeparatorChar + "File/";
        if (!Directory.Exists(directory))  // if it doesn't exist, create
            Directory.CreateDirectory(directory);
    }
    
    StreamReader input = null;
    StreamWriter output = null;
    public void saveProcess(string points)
    {
        string filePath = directory + @processFile;
        if (!File.Exists(filePath))
        {
            output = File.CreateText(directory + @processFile);
            if (output != null)
            {
                output.Close();
            }
            return;
        }
        try
        {
            output = File.CreateText(directory + @processFile);
            output.WriteLine(points);
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        finally
        {
            //if(input != null)
            //{
            //    input.Close();
            //}
            if (output != null)
            {
                output.Close();
            }
        }
    }

        public string readProcess()
        {
        string line = "0";
        string filePath = directory + @processFile;
        if (!File.Exists(filePath))
        {
            output = File.CreateText(directory + @processFile);
            if (output != null)
            {
                output.Close();
            }
            return line;
        }
        try
        {
            input = File.OpenText(directory + @processFile);
            line = input.ReadLine();
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
            
        return line;
    }

    public void saveHighScore(Dictionary<string, int> dict)
    {
        string filePath = directory + @highscoreFile;
        if (!File.Exists(filePath))
        {
            output = File.CreateText(directory + @highscoreFile);
            if (output != null)
            {
                output.Close();
            }
            return;
        }
        try
        {
            output = File.CreateText(directory + @highscoreFile);
            int i = 0;
            foreach(KeyValuePair<string, int> kvp in dict)
            {
                if (i < 5)
                {
                    output.WriteLine(kvp.Key + ";" + kvp.Value);
                    i++;
                }
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        finally
        {
            if (output != null)
            {
                output.Close();
            }
        }
    }

    public Dictionary<string, int> readHighScore()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string filePath = directory + @highscoreFile;
        if (!File.Exists(filePath))
        {
            output = File.CreateText(directory + @highscoreFile);
            if (output != null)
            {
                output.Close();
            }
        }
        try
        {
            input = File.OpenText(directory + @highscoreFile);
            for(int i = 0; i < 5; i++)
            {
                string[] line = input.ReadLine().Split(";");
                dict.Add(line[0], Int32.Parse(line[1]));
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }

        return dict;
    }
}

