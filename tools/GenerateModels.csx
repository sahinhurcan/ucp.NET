#!/usr/bin/env dotnet-script
#r "nuget: NJsonSchema, 11.0.2"
#r "nuget: NJsonSchema.CodeGeneration.CSharp, 11.0.2"

using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using System.IO;
using System.Text;

var rootDir = Path.Combine(Directory.GetCurrentDirectory());
var specDir = Path.Combine(rootDir, "spec", "schemas");
var outputDir = Path.Combine(rootDir, "src", "UCP.NET", "Models");

Directory.CreateDirectory(outputDir);

// Find all JSON schema files
var schemaFiles = Directory.GetFiles(specDir, "*.json", SearchOption.AllDirectories)
    .Where(f => !f.Contains("service_schema.json"))
    .ToList();

Console.WriteLine($"Found {schemaFiles.Count} schema files");

var settings = new CSharpGeneratorSettings
{
    Namespace = "UCP.NET.Models",
    ClassStyle = CSharpClassStyle.Poco,
    GenerateDataAnnotations = true,
    GenerateJsonMethods = false,
    JsonLibrary = CSharpJsonLibrary.SystemTextJson,
    GenerateDefaultValues = true,
    GenerateNullableReferenceTypes = true,
    RequiredPropertiesMustBeDefined = true
};

foreach (var schemaFile in schemaFiles)
{
    try
    {
        Console.WriteLine($"Processing: {Path.GetFileName(schemaFile)}");
        
        var json = File.ReadAllText(schemaFile);
        var schema = await JsonSchema.FromJsonAsync(json);
        
        var generator = new CSharpGenerator(schema, settings);
        var code = generator.GenerateFile();
        
        // Generate output file name from schema file name
        var fileName = Path.GetFileNameWithoutExtension(schemaFile);
        fileName = fileName.Replace(".", "_");
        fileName = ToPascalCase(fileName);
        
        var outputFile = Path.Combine(outputDir, $"{fileName}.cs");
        
        // Add license header
        var header = @"// Copyright 2026 UCP Authors
//
// Licensed under the Apache License, Version 2.0 (the ""License"");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an ""AS IS"" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

";
        
        File.WriteAllText(outputFile, header + code);
        Console.WriteLine($"  -> Generated: {fileName}.cs");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"  -> Error: {ex.Message}");
    }
}

Console.WriteLine("Model generation complete!");

string ToPascalCase(string input)
{
    var parts = input.Split(new[] { '_', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);
    var result = string.Join("", parts.Select(p => char.ToUpper(p[0]) + p.Substring(1).ToLower()));
    return result;
}
