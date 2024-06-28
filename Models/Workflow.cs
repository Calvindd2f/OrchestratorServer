using System;
using System.Collections.Generic;

namespace OrchestratorServer.Models
{
    public class Workflow
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PackageName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string ValueProp { get; set; }

        public List<HighLevelStep> HighLevelSteps { get; set; } = new List<HighLevelStep>();
        public List<Condition> Conditions { get; set; } = new List<Condition>();
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<PackageVariable> Variables { get; set; } = new List<PackageVariable>();
        public PackageData PackageData { get; set; }
        public List<string> Integrations { get; set; } = new List<string>();
    }

    public class Node
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        public NodeData Data { get; set; }
        public Position Position { get; set; }
    }

    public class NodeData
    {
        [MaxLength(100)]
        public string Label { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public Step Step { get; set; }
        public Details Details { get; set; }
        public Analysis Analysis { get; set; }
    }

    public class Step
    {
        public string Task { get; set; }
        public Dictionary<string, string> Inputs { get; set; }
        public string Alias { get; set; }
        public string Skip { get; set; }
        public string Document { get; set; }
    }

    public class Details
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public int ModifiedByUserId { get; set; }
        public string ActivityStaticName { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public string ImageBlobId { get; set; }
        public string ImageDownloadUrl { get; set; }
        public string ImageName { get; set; }
        public string PowerShellCode { get; set; }
        public bool SafeImmutable { get; set; }
        public bool IsPublished { get; set; }
        public bool IsLatestVersion { get; set; }
        public int Version { get; set; }
        public bool IsDeleted { get; set; }
        public string SaveToken { get; set; }
        public List<TagElement> Tags { get; set; }
        public List<Variable> Variables { get; set; }
        public int SandboxId { get; set; }
        public bool IsLocked { get; set; }
        public string StaticName { get; set; }
        public bool DisplayGoButton { get; set; }
        public bool IsReadOnly { get; set; }
        public string DisplayName { get; set; }
        public string FormJson { get; set; }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
    }

    public class Analysis
    {
        public string Summary { get; set; }
        public string FiveWordSummary { get; set; }
        public int CountOfActiveLinesOfCode { get; set; }
        public List<string> Integrations { get; set; }
        public List<string> CodeReview { get; set; }
        public string StaticName { get; set; }
    }

    public class PackageVariable
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsGlobal { get; set; }
    }

    public class HighLevelStep
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string StartNodeId { get; set; }
        public string EndNodeId { get; set; }
    }

    public class PackageData
    {
        public int Id { get; set; }
        public string InternalId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public int ModifiedByUserId { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public string YamlCode { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsLatestVersion { get; set; }
        public int Version { get; set; }
        public bool IsLocked { get; set; }
        public string SaveToken { get; set; }
        public List<TagElement> Tags { get; set; }
        public List<PackageVariable> Variables { get; set; }
        public int SandboxId { get; set; }
        public int DefinitionVersion { get; set; }
    }

    public class Variable
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public bool IsOutputVariable { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public string Description { get; set; }
        public string DefaultValue { get; set; }
        public string TestValue { get; set; }
        public string OptionText { get; set; }
    }

    public class TagElement
    {
        public int Id { get; set; }
        public int TagType { get; set; }
        public string Tag { get; set; }
        public string CwKey { get; set; }
        public string Color { get; set; }
        public DateTime Created { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedByUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
