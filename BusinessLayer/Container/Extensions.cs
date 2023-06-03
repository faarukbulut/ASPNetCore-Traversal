using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IGenericService<Comment>, CommentManager>();
            builder.Services.AddScoped<IGenericDal<Comment>, EfGenericDal<Comment>>();

            builder.Services.AddScoped<IGenericService<Destination>, DestinationManager>();
            builder.Services.AddScoped<IGenericDal<Destination>, EfGenericDal<Destination>>();

            builder.Services.AddScoped<IGenericService<AppUser>, AppUserManager>();
            builder.Services.AddScoped<IGenericDal<AppUser>, EfGenericDal<AppUser>>();

            builder.Services.AddScoped<IGenericService<Reservation>, ReservationManager>();
            builder.Services.AddScoped<IGenericDal<Reservation>, EfGenericDal<Reservation>>();

            builder.Services.AddScoped<IGenericService<SubAbout>, SubAboutManager>();
            builder.Services.AddScoped<IGenericDal<SubAbout>, EfGenericDal<SubAbout>>();

            builder.Services.AddScoped<IGenericService<Testimonial>, TestimonialManager>();
            builder.Services.AddScoped<IGenericDal<Testimonial>, EfGenericDal<Testimonial>>();

            builder.Services.AddScoped<IGenericService<Guide>, GuideManager>();
            builder.Services.AddScoped<IGenericDal<Guide>, EfGenericDal<Guide>>();

            builder.Services.AddScoped<IGenericService<About>, AboutManager>();
            builder.Services.AddScoped<IGenericDal<About>, EfGenericDal<About>>();

            builder.Services.AddScoped<IAccountService, AccountManager>();
            builder.Services.AddScoped<IAccountDal, EfAccountDal>();
            builder.Services.AddScoped<IUowDal, UowDal>();

        }
    }
}
