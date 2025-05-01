using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using USDA.ARS.GRIN.GRINGlobal.API.Data.Models;
namespace USDA.ARS.GRIN.GRINGlobal.API.Web;

public static class taxonomy_speciesEndpoints
{
    public static void Maptaxonomy_speciesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/taxonomy_species").WithTags(nameof(taxonomy_species));

        //NO.
        //group.MapGet("/", async (gringlobalContext db) =>
        //{
        //    return await db.taxonomy_species.ToListAsync();
        //})
        //.WithName("GetAlltaxonomy_species")
        //.WithOpenApi();

        group.MapGet("/{taxonomy_species_id}", async Task<Results<Ok<taxonomy_species>, NotFound>> (int taxonomy_species_id, gringlobalContext db) =>
        {
            return await db.taxonomy_species.AsNoTracking()
                .FirstOrDefaultAsync(model => model.taxonomy_species_id == taxonomy_species_id)
                is taxonomy_species model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("Gettaxonomy_speciesById")
        .WithOpenApi();

        group.MapPut("/{taxonomy_species_id}", async Task<Results<Ok, NotFound>> (int taxonomy_species_id, taxonomy_species taxonomy_species, gringlobalContext db) =>
        {
            var affected = await db.taxonomy_species
                .Where(model => model.taxonomy_species_id == taxonomy_species_id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.taxonomy_species_id, taxonomy_species.taxonomy_species_id)
                    .SetProperty(m => m.current_taxonomy_species_id, taxonomy_species.current_taxonomy_species_id)
                    .SetProperty(m => m.nomen_number, taxonomy_species.nomen_number)
                    .SetProperty(m => m.is_specific_hybrid, taxonomy_species.is_specific_hybrid)
                    .SetProperty(m => m.species_name, taxonomy_species.species_name)
                    .SetProperty(m => m.species_authority, taxonomy_species.species_authority)
                    .SetProperty(m => m.is_subspecific_hybrid, taxonomy_species.is_subspecific_hybrid)
                    .SetProperty(m => m.subspecies_name, taxonomy_species.subspecies_name)
                    .SetProperty(m => m.subspecies_authority, taxonomy_species.subspecies_authority)
                    .SetProperty(m => m.is_varietal_hybrid, taxonomy_species.is_varietal_hybrid)
                    .SetProperty(m => m.variety_name, taxonomy_species.variety_name)
                    .SetProperty(m => m.variety_authority, taxonomy_species.variety_authority)
                    .SetProperty(m => m.is_subvarietal_hybrid, taxonomy_species.is_subvarietal_hybrid)
                    .SetProperty(m => m.subvariety_name, taxonomy_species.subvariety_name)
                    .SetProperty(m => m.subvariety_authority, taxonomy_species.subvariety_authority)
                    .SetProperty(m => m.is_forma_hybrid, taxonomy_species.is_forma_hybrid)
                    .SetProperty(m => m.forma_rank_type, taxonomy_species.forma_rank_type)
                    .SetProperty(m => m.forma_name, taxonomy_species.forma_name)
                    .SetProperty(m => m.forma_authority, taxonomy_species.forma_authority)
                    .SetProperty(m => m.taxonomy_genus_id, taxonomy_species.taxonomy_genus_id)
                    .SetProperty(m => m.priority1_site_id, taxonomy_species.priority1_site_id)
                    .SetProperty(m => m.priority2_site_id, taxonomy_species.priority2_site_id)
                    .SetProperty(m => m.curator1_cooperator_id, taxonomy_species.curator1_cooperator_id)
                    .SetProperty(m => m.curator2_cooperator_id, taxonomy_species.curator2_cooperator_id)
                    .SetProperty(m => m.restriction_code, taxonomy_species.restriction_code)
                    .SetProperty(m => m.life_form_code, taxonomy_species.life_form_code)
                    .SetProperty(m => m.common_fertilization_code, taxonomy_species.common_fertilization_code)
                    .SetProperty(m => m.is_name_pending, taxonomy_species.is_name_pending)
                    .SetProperty(m => m.synonym_code, taxonomy_species.synonym_code)
                    .SetProperty(m => m.verifier_cooperator_id, taxonomy_species.verifier_cooperator_id)
                    .SetProperty(m => m.name_verified_date, taxonomy_species.name_verified_date)
                    .SetProperty(m => m.name, taxonomy_species.name)
                    .SetProperty(m => m.name_authority, taxonomy_species.name_authority)
                    .SetProperty(m => m.protologue, taxonomy_species.protologue)
                    .SetProperty(m => m.protologue_virtual_path, taxonomy_species.protologue_virtual_path)
                    .SetProperty(m => m.note, taxonomy_species.note)
                    .SetProperty(m => m.site_note, taxonomy_species.site_note)
                    .SetProperty(m => m.alternate_name, taxonomy_species.alternate_name)
                    .SetProperty(m => m.created_date, taxonomy_species.created_date)
                    .SetProperty(m => m.created_by, taxonomy_species.created_by)
                    .SetProperty(m => m.modified_date, taxonomy_species.modified_date)
                    .SetProperty(m => m.modified_by, taxonomy_species.modified_by)
                    .SetProperty(m => m.owned_date, taxonomy_species.owned_date)
                    .SetProperty(m => m.owned_by, taxonomy_species.owned_by)
                    .SetProperty(m => m.hybrid_parentage, taxonomy_species.hybrid_parentage)
                    .SetProperty(m => m.is_web_visible, taxonomy_species.is_web_visible)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("Updatetaxonomy_species")
        .WithOpenApi();

        group.MapPost("/", async (taxonomy_species taxonomy_species, gringlobalContext db) =>
        {
            db.taxonomy_species.Add(taxonomy_species);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/taxonomy_species/{taxonomy_species.taxonomy_species_id}",taxonomy_species);
        })
        .WithName("Createtaxonomy_species")
        .WithOpenApi();

        group.MapDelete("/{taxonomy_species_id}", async Task<Results<Ok, NotFound>> (int taxonomy_species_id, gringlobalContext db) =>
        {
            var affected = await db.taxonomy_species
                .Where(model => model.taxonomy_species_id == taxonomy_species_id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("Deletetaxonomy_species")
        .WithOpenApi();
    }
}
