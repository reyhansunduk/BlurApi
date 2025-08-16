using BlurApi.Abstract;
using BlurApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlurApi.Controllers
{
    [ApiController]
    [Route("api/enterprices")]
    public class EnterpriceController : ControllerBase
    {
        private readonly IEnterpriceService _service;

        public EnterpriceController(IEnterpriceService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Enterprices>> GetAll()
        {
            var list = _service.GetAll();
            return Ok(list);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<Enterprices> GetById(Guid id)
        {
            var entity = _service.GetById(id);
            if (entity == null)
                return NotFound(new { message = "Kayıt bulunamadı" });

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Enterprices model)
        {
            _service.Add(model);
            return Ok(new { data = model });
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, [FromBody] Enterprices model)
        {
            if (id != model.Id)
                return BadRequest(new { message = "Id eşleşmiyor" });

            _service.Update(model);
            return Ok(new { message = "Kayıt güncellendi" });
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return Ok(new { message = "Kayıt silindi" });
        }

        [HttpPatch("{id:guid}/toggle-status")]
        public IActionResult ToggleStatus(Guid id)
        {
            var entity = _service.GetById(id);
            if (entity == null)
                return NotFound(new { message = "Kayıt bulunamadı" });

            entity.Disabled = !entity.Disabled;
            _service.Update(entity);

            return Ok(new { 
                message = entity.Disabled ? "Şirket devre dışı bırakıldı" : "Şirket aktifleştirildi",
                data = entity 
            });
        }
    }
}
