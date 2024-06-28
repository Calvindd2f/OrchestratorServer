using OrchestratorServer.Models;
using OrchestratorServer.Repositories;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OrchestratorServer.Services
{
    public class WorkflowExecutionService : IWorkflowExecutionService
    {
        private readonly IWorkflowRepository _workflowRepository;

        public WorkflowExecutionService(IWorkflowRepository workflowRepository)
        {
            _workflowRepository = workflowRepository;
        }

        public async Task ExecuteWorkflowAsync(int packageId)
        {
            // Retrieve the package
            var package = await _workflowRepository.GetByIdAsync(packageId);
            if (package == null)
            {
                throw new NotFoundException($"Package with id {packageId} not found.");
            }

            // Execute the PowerShell script from the package
            foreach (var node in package.Nodes)
            {
                if (node.Type == "activity")
                {
                    var script = node.Data.Step.Script;
                    var result = ExecutePowerShellScript(script);
                    // Process the result as needed
                }
                else if (node.Type == "form")
                {
                    // Pause for user input
                    await PauseWorkflowForInputAsync(packageId, node.Data.FormJson);
                }
            }
        }

        private string ExecutePowerShellScript(string script)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-Command {script}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = processStartInfo };
            process.Start();
            var result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }

        public async Task UpdateWorkflowStatusAsync(int packageId, string status)
        {
            // Update the status of the workflow
            var package = await _workflowRepository.GetByIdAsync(packageId);
            if (package == null)
            {
                throw new NotFoundException($"Package with id {packageId} not found.");
            }

            package.Status = status;
            await _workflowRepository.UpdateAsync(package);
        }

        public async Task PauseWorkflowForInputAsync(int packageId, string formData)
        {
            // Save the form data and pause the workflow
            var package = await _workflowRepository.GetByIdAsync(packageId);
            if (package == null)
            {
                throw new NotFoundException($"Package with id {packageId} not found.");
            }

            package.PausedFormData = formData;
            await _workflowRepository.UpdateAsync(package);
        }
    }
}
