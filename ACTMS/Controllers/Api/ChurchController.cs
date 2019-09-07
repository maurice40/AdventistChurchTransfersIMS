using ACTMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ACTMS.Dtos;
using ACTMS.Models;
using AutoMapper;

namespace ACTMS.Controllers.Api
{
    public class ChurchController : ApiController
    {
        private ApplicationDbContext _context;

        public ChurchController()
        {
            _context = new ApplicationDbContext();
        }

       /* // GET /api/customers
        public IHttpActionResult GetChurches(string query = null)
        {
            var churchesQuery = _context.churches.ToList();
              //  .Include(c => c.MembershipType);

           // if (!String.IsNullOrWhiteSpace(query))
           //     churchesQuery = churchesQuery.Where(c => c.Name.Contains(query));

            var churchDto = churchesQuery
                .ToList()
                .Select(Mapper.Map<ACTMS.Models.Church, ChurchDto>);
            
            return Ok(churchDto);    
        }

        // GET /api/customers/1
        public IHttpActionResult GetChurch(int id)
        {
            var customer = _context.churches.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Church, ChurchDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(ChurchDto churchDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var church = Mapper.Map<ChurchDto, Church>(churchDto);
            _context.churches.Add(church);
            _context.SaveChanges();

            churchDto.Id = church.Id;
            return Created(new Uri(Request.RequestUri + "/" + church.Id), churchDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateChurch(int id, ChurchDto churchDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var churchInDb = _context.churches.SingleOrDefault(c => c.Id == id);

            if (churchInDb == null)
                return NotFound();

            Mapper.Map(churchDto, churchInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var churchInDb = _context.churches.SingleOrDefault(c => c.Id == id);

            if (churchInDb == null)
                return NotFound();

            _context.churches.Remove(churchInDb);
            _context.SaveChanges();

            return Ok();
        }*/
        public IEnumerable<ChurchDto> GetChurches()
        {
            return _context.churches
                .Include(c=> c.Province)
                .ToList()
                .Select(Mapper.Map<Church, ChurchDto>);
        }

        public IHttpActionResult GetChurch(int Id)
        {
            var church = _context.churches.SingleOrDefault(c => c.Id == Id);

            if (church == null)
                // new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok(Mapper.Map<Church, ChurchDto>(church));
        }

        [HttpPost]
        public IHttpActionResult CreateChurch(ChurchDto churchDto)
        {
            if (!ModelState.IsValid){
                return BadRequest();
            }
            var church = Mapper.Map<ChurchDto, Church>(churchDto);
            _context.churches.Add(church);
            _context.SaveChanges();

            churchDto.Id = church.Id;

            return Created(new Uri(Request.RequestUri + "/" + church.Id), churchDto);
        }

        [HttpPut]
        public void UpdateChurch (int Id , ChurchDto churchDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var churchInDB = _context.churches.SingleOrDefault(c => c.Id == Id);

            if (churchInDB==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //Mapper.Map<ChurchDto, Church>(churchDto, churchInDB);
            Mapper.Map(churchDto, churchInDB);

            /* 
            churchInDB.Name = churchDto.Name;
            churchInDB.Address = churchDto.Address;
            churchInDB.ProvinceId = churchDto.ProvinceId;*/

            _context.SaveChanges();



        }

        [HttpDelete]
        public void DeleteChurch(int Id)
        {
            var churchInDB = _context.churches.SingleOrDefault(c => c.Id == Id);

            if (churchInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.churches.Remove(churchInDB);
            _context.SaveChanges();
        }

    }
  
}

