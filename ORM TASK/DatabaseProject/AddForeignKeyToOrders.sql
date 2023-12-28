ALTER TABLE orders
ADD CONSTRAINT FK_Orders_Products FOREIGN KEY (ProductId) 
REFERENCES products(id)