-- Lock ex
BEGIN TRAN
--pas 2
UPDATE classroom SET classroom_name = 'new name' WHERE id = 1;
--pas 4
UPDATE class SET class_name = 'POO' WHERE id = 1;

COMMIT TRAN

--Dirty read
BEGIN TRAN
-- pas 2
UPDATE classroom SET classroom_name = 'name' WHERE id = 1;

ROLLBACK

--Non repeatable read
BEGIN TRAN
--pas 2
UPDATE classroom SET classroom_name = 'name' WHERE id = 1;
COMMIT TRAN

-- Phantom read
BEGIN TRAN
--pas 2
INSERT INTO classroom(classroom_name, classroom_location, capacity) VALUES ('name 2', 'location 2', 15);
COMMIT TRAN