﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TypeGen.Core.Validation;

namespace TypeGen.Core.Storage
{
    /// <summary>
    /// Represents the file system
    /// </summary>
    internal class FileSystem : IFileSystem
    {
        /// <inheritdoc />
        public void SaveFile(string filePath, string content)
        {
            Requires.NotNullOrEmpty(filePath, nameof(filePath));
            Requires.NotNull(content, nameof(content));
            
            new FileInfo(filePath).Directory?.Create();
            File.WriteAllText(filePath, content);
        }

        /// <inheritdoc />
        public string ReadFile(string filePath)
        {
            Requires.NotNullOrEmpty(filePath, nameof(filePath));
            return File.ReadAllText(filePath);
        }

        /// <inheritdoc />
        public bool FileExists(string filePath)
        {
            Requires.NotNullOrEmpty(filePath, nameof(filePath));
            return File.Exists(filePath);
        }

        /// <inheritdoc />
        public IEnumerable<string> GetFilesRecursive(string rootDirectory, string fileName)
        {
            Requires.NotNullOrEmpty(rootDirectory, nameof(rootDirectory));
            Requires.NotNullOrEmpty(fileName, nameof(fileName));
            
            return Directory.GetFiles(rootDirectory, fileName, SearchOption.AllDirectories);
        }

        /// <inheritdoc />
        public bool DirectoryExists(string directory)
        {
            Requires.NotNullOrEmpty(directory, nameof(directory));
            return Directory.Exists(directory);
        }

        /// <inheritdoc />
        public IEnumerable<string> GetDirectoryFiles(string directory)
        {
            Requires.NotNullOrEmpty(directory, nameof(directory));
            return Directory.GetFiles(directory);
        }

        /// <inheritdoc />
        public string GetCurrentDirectory() => Directory.GetCurrentDirectory();
    }
}
