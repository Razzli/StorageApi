using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly StorageApiContext _context;
    public ProductsController(StorageApiContext context)
    {
        _context = context;
    }

    // GET: api/Product
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProduct()
    {

        return (await _context.Product.ToListAsync()).Select(
            Product =>
            new ProductDTO(Product.Id, Product.Name, Product.Price, Product.Category, Product.Shelf, Product.Count, Product.Description))
            .ToList();
    }
    

    // GET: api/Product/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        Product product = await _context.Product.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return new ProductDTO(product.Id, product.Name, product.Price, product.Category, product.Shelf, product.Count, product.Description);
    }

    // GET: api/Product/stats
    [HttpGet("Stats")]
    public async Task<IEnumerable<ProductStatsDTO>> GetStats()
    {
        List<Product> products = await _context.Product.ToListAsync();
        List<ProductDTO> productDTOs = products.Select(
            Product =>
            new ProductDTO(Product.Id, Product.Name, Product.Price, Product.Category, Product.Shelf, Product.Count, Product.Description))
            .ToList();
        int count = productDTOs.Sum(ProductDTO => ProductDTO.Count);
        int value = productDTOs.Sum(ProductDTO => ProductDTO.InventoryValue);
        return [new ProductStatsDTO(count, value)];
    }
    // GET: api/Product/Category/?Category
    [HttpGet("Category")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategory([FromQuery(Name = "category")] string Category)
    {
        return (await _context.Product.ToListAsync()).Select(
            Product =>
            new ProductDTO(Product.Id, Product.Name, Product.Price, Product.Category, Product.Shelf, Product.Count, Product.Description))
            .Where(ProductDTO => ProductDTO.Category == Category)
            .Select(ProductDTO => new CategoryDTO(ProductDTO.Category)).Distinct().ToList();
    }

    // PUT: api/Product/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int? id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Product
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    // DELETE: api/Product/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Product.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int? id)
    {
        return _context.Product.Any(e => e.Id == id);
    }
}
