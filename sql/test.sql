SELECT p.Name , c.Name 
FROM learning.Products p
LEFT JOIN learning.ProductsCategories pc ON p.Id = pc.ProductId 
LEFT JOIN learning.Categories c ON pc.CategoryId = c.Id;