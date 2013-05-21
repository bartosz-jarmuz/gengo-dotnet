﻿//
// Jobs.cs
//
// Author:
//       Jarl Erik Schmidt <github@jarlerik.com>
//
// Copyright (c) 2013 Jarl Erik Schmidt
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


namespace Winterday.External.Gengo.MethodGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json.Linq;

    using Winterday.External.Gengo.Payloads;
    using Winterday.External.Gengo.Properties;

    public class JobsEndpoint
    {
        internal const string UriPartJobsEndpoint = "translate/jobs";

        readonly IGengoClient _client;

        internal JobsEndpoint(IGengoClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            _client = client;
        }

        public Task<SubmittedJob[]> GetJobsByIds(params int[] jobIds) {

            if (jobIds == null) throw new ArgumentNullException("jobIds");

            if (jobIds.Length == 0)
            {
                return Task.FromResult(new SubmittedJob[] { });
            }
            else
            {
                return GetJobsByIds((IEnumerable<int>)jobIds);
            }
        }

        public async Task<SubmittedJob[]> GetJobsByIds(IEnumerable<int> jobIds)
        {
            if (jobIds == null) throw new ArgumentNullException("jobIds");

            var sb = new StringBuilder("/");

            foreach (var item in jobIds)
            {
                if (item <= 0)
                    throw new ArgumentException(
                        Resources.InvalidJobIdProvided, "jobIds");

                if (sb.Length > 1)
                    sb.Append(",");

                sb.Append(item);
            }

            if (sb.Length == 1)
            {
                return new SubmittedJob[] { };
            }

            var url = UriPartJobsEndpoint + sb.ToString();
            var json = await _client.GetJsonAsync<JObject>(url, true);

            var arr = json.Value<JArray>("jobs");

            return arr.Values<JObject>().Select(
                o => new SubmittedJob(o)).ToArray();
        }

        public async Task<TimestampedId[]> GetRecentJobs(
            TranslationStatus? status = null,
            DateTime? afterDateTime = null,
            int maxCount = 10
            )
        {
            var args = new Dictionary<string, string>();

            if (status.HasValue &&
                status.Value == TranslationStatus.Unknown)
            {
                throw new ArgumentException(
                    Resources.CannotRequestJobsWithUnknownStatus,
                    "status");
            }
            else if (status.HasValue)
            {
                args["status"] = status.Value.ToStatusString(); 
            }

            if (afterDateTime.HasValue)
            {
                var ts = afterDateTime.Value.ToTimeStamp();

                if (ts <= 0)
                {
                    throw new ArgumentException(
                        Resources.CannotRequestJobsWithPreUnixTime,
                        "afterDateTime");
                }

                args["timestamp_after"] = ts.ToString();
            }

            if (maxCount <= 0)
            {
                return new TimestampedId[] { };
            }
            else
            {
                args["count"] = maxCount.ToString();
            }

            var json = await _client.GetJsonAsync<JArray>(UriPartJobsEndpoint, args, true);

            return json.Values<JObject>().Select(o =>
                new TimestampedId(o, "job_id", "ctime")).ToArray();
        }

        public Task<Confirmation> Submit(
            bool requireSameTranslator,
            bool allowTranslatorChange,
            params Job[] jobs)
        {
            if (jobs == null) throw new ArgumentNullException("jobs");

            return Submit(
                requireSameTranslator,
                allowTranslatorChange,
                (IEnumerable<Job>)jobs);
        }

        public async Task<Confirmation> Submit(
            bool requireSameTranslator,
            bool allowTranslatorChange,
            IEnumerable<Job> jobs)
        {
            if (jobs == null) throw new ArgumentNullException("jobs");

            var tpl = jobs.ToJsonJobsList();
            var jobsObj = tpl.Item1;
            var mapping = tpl.Item2;

            if (!jobsObj.HasValues)
                throw new ArgumentException(
                    Resources.AtLeastOneJobRequired);

            var payload = new JObject();
            payload["jobs"] = jobsObj;
            payload["as_group"] = Convert.ToInt32(requireSameTranslator);
            payload["allow_fork"] = Convert.ToInt32(allowTranslatorChange);

            var response =
                await _client.PostJsonAsync<JObject>(
                UriPartJobsEndpoint,
                payload);

            return new Confirmation(mapping, response);
        }
    }
}