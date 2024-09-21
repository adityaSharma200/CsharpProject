CREATE PROCEDURE UpdateEmployee
(
    @id INT,
    @name nchar(10),
    @email nchar(10),
    @phone varchar(20),
    @city nchar(10),
    @gender nchar(10)
    )
AS
BEGIN
        UPDATE Employee
        SET name = @name, email = @email, phone = @phone, city = @city , gender = @gender
        WHERE id = @id;
    END