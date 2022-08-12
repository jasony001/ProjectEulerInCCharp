using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using ProjectEulerDataContracts;
using ProjectEulerLib;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;

namespace ProjectEulerWebAPI.Controllers
{
    [ApiController]
    public class ProblemControllers : ControllerBase
    {
        private readonly ILogger<ProblemControllers> _logger;
        private readonly ProblemSolverFactory _problemSolverFactory;

        public ProblemControllers(ILogger<ProblemControllers> logger, ProblemSolverFactory problemSolverFactory)
        {
            _logger = logger;
            _problemSolverFactory = problemSolverFactory;

        }

        [HttpGet]
        [Route("/CalulatedProblemSolutions")]
        public ActionResult<Problem> CalulatedProblemSolutions(int? problemId)
        {
            try
            {
                if (!problemId.HasValue) throw new ArgumentException("problemId is required.");
                ProblemSolver p = _problemSolverFactory.GetProblem(problemId.Value);
                if (p == null) throw new ArgumentException($"problem{problemId} is not yet defined.");
                p.SolveProblem();

                return Ok(p.Problem);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("GetCalulatedProblemSolutions", ex.Message);
                return BadRequest(ModelState);
            }
        }


        [HttpGet]
        [Route("/AvailableProblemIdList")]
        public ActionResult<List<string>> GetAvailableProblemIdList()
        {
            try
            {
                List<string> idList = _problemSolverFactory.GetAvailableProblemIdList();

                return Ok(idList);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("GetCalulatedProblemSolutions", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}