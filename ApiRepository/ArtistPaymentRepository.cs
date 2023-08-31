using ApiDBAccess;
using ApiDTOModels;
using ApiModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class ArtistPaymentRepository : IArtistPaymentRepository
    {
        Database db = new();




        public async Task<List<ArtistPayment>> GetArtistPayments()
        {
            List<ArtistPayment> artistPayments = new List<ArtistPayment>();
            List<DtoArtistPayment> dtoArtistPayments;
            try
            {
                dtoArtistPayments = await db.ArtistPayments.ToListAsync();
            }
            catch (Exception)
            {
                return new List<ArtistPayment>();
            }

            foreach (DtoArtistPayment payment in dtoArtistPayments)
            {
                ArtistPayment artistPayment = new ArtistPayment
                {
                    Id = payment.Id,
                    StartDate = payment.StartDate,
                    EndDate = payment.EndDate,
                    ArtistId = payment.ArtistId
                };
                artistPayments.Add(artistPayment);
            }
            return artistPayments;
        }


        public async Task<ArtistPayment> GetArtistPayments(int id)
        {
            DtoArtistPayment artistPayment;
            artistPayment = await db.ArtistPayments.FirstOrDefaultAsync(x => x.Id == id);
            ArtistPayment payment = new ArtistPayment
            {
                Id = artistPayment.Id,
                ArtistId = artistPayment.ArtistId,
                StartDate = artistPayment.StartDate,
                EndDate = artistPayment.EndDate,
            };
            return payment;
        }

        public async Task<bool> Create(ArtistPayment artistPayment)
        {
            DtoArtistPayment dtoArtistPayment = new DtoArtistPayment
            {
                Id = artistPayment.Id,
                ArtistId = artistPayment.ArtistId,
                StartDate = artistPayment.StartDate,
                EndDate = artistPayment.EndDate
            };
            await db.ArtistPayments.AddAsync(dtoArtistPayment);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Update(ArtistPayment artistPayment)
        {
            DtoArtistPayment dtoArtistPayment = await db.ArtistPayments.FirstOrDefaultAsync(x => x.Id == artistPayment.Id);

            dtoArtistPayment.Id = artistPayment.Id;
            dtoArtistPayment.ArtistId = artistPayment.ArtistId;
            dtoArtistPayment.StartDate = artistPayment.StartDate;
            dtoArtistPayment.EndDate = artistPayment.EndDate;

            db.ArtistPayments.Update(dtoArtistPayment);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            DtoArtistPayment dtoArtistPayment = await db.ArtistPayments.FirstOrDefaultAsync(x => x.Id == id);

            db.ArtistPayments.Remove(dtoArtistPayment);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
