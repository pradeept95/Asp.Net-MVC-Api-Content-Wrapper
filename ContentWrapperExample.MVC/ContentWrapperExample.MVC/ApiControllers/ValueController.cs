
using Api.Helper.ContentWrapper.MVC.ResponseModel;
using System.Collections.Generic;
using System.Web.Http;

namespace ContentWrapperExample.MVC.ApiControllers
{
    [Route("api/value")]
    public class ValueController : ApiController
    {
        [HttpGet]
        [Route("getone")]
        public Api.Helper.ContentWrapper.MVC.ResponseModel.ResultDto<string> Get()
        {
            return new Api.Helper.ContentWrapper.MVC.ResponseModel.ResultDto<string>("Result");
        }

        //[Route("get")]
        //[HttpGet]
        //public ListResultDto<string> GetOne()
        //{
        //    var result = new List<string>();
        //    result.Add("date 1");
        //    result.Add("date 2");
        //    result.Add("date 3");
        //    result.Add("date 4");
        //    result.Add("date 5");
        //    result.Add("date 6");
        //    result.Add("date 7");
        //    return new ListResultDto<string>(result);
        //}


        //[Route("excExample")]
        //[HttpGet]
        //public List<string> GetExcResult()
        //{
        //    throw new Api.Helper.ContentWrapper.MVC.Wrappers.ApiException("Your Message", 401, Api.Helper.ContentWrapper.MVC.Extensions.ModelStateExtension.AllErrors(ModelState));
        //    var result = new List<string>();
        //    result.Add("date 1");
        //    result.Add("date 2");
        //    result.Add("date 3");
        //    result.Add("date 4");
        //    result.Add("date 5");
        //    result.Add("date 6");
        //    result.Add("date 7");
        //    return result;
        //}

        //[Route("save")]
        //[HttpPost]
        ////[Api.Helper.ContentWrapper.MVC.Filters.ValidateModelState]
        //public ResultDto<PostModel> PostExample(PostModel model)
        //{
        //    return new ResultDto<PostModel>(model);
        //}


        [Route("saveandGetList")]
        [HttpPost]
        public ListResultDto<PostModel> PostAngGetListExample(PostModel model)
        {
            var result = new List<PostModel>();
            result.Add(model);
            result.Add(model);
            result.Add(model);

            return new ListResultDto<PostModel>(result);
        }

        //[Route("saveandGetListWithPage")]
        //[HttpPost]
        //public PagedResultDto<PostModel> PostAngGetListWithPageExample(PostModel model)
        //{
        //    var result = new List<PostModel>();
        //    result.Add(model);
        //    result.Add(model);
        //    result.Add(model);

        //    var totalCount = result.Count;
        //    return new PagedResultDto<PostModel>(totalCount, result);
        //}
    }

    public class PostModel
    {
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(5, ErrorMessage = "Min Length is 5.")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Address { get; set; }
         
        public List<SecondModel> SecondModel { get; set; }
    }

    public class SecondModel
    {
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(5, ErrorMessage = "Min Length is 5.")]
        public string Prop1 { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Prop2 { get; set; }
    }
}
