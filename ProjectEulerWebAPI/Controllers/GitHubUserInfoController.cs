using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using ProjectEulerDataContracts;
using ProjectEulerLib;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;

namespace ProjectEulerWebAPI.Controllers
{
    [ApiController]
    public class GitHubUserInfoController : ControllerBase
    {
        private readonly ILogger<GitHubUserInfoController> _logger;
        private readonly IConfiguration _configuration;
        public GitHubUserInfoController(ILogger<GitHubUserInfoController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/GitHubUserInfo/AccessToken")]
        public ActionResult GetAccessToken()
        {
            return Ok(new {token = "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"});
        }

    }
}