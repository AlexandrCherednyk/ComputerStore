USE `computer_store`;

DROP TRIGGER IF EXISTS `Output_count_greater_than_or_equal_to_zero`;

CREATE TRIGGER `Output_count_greater_than_or_equal_to_zero`
BEFORE INSERT
ON `Output`
FOR EACH ROW
IF NEW.`Count` < 0 THEN 
SIGNAL SQLSTATE '45000'
SET MESSAGE_TEXT = 'Output count cannot be less than 0.';
END IF;

DROP TRIGGER IF EXISTS `Output_total_price_greater_than_or_equal_to_zero`;

CREATE TRIGGER `Output_total_price_greater_than_or_equal_to_zero`
BEFORE INSERT
ON `Output`
FOR EACH ROW
IF NEW.`TotalPrice` < 0 THEN 
SIGNAL SQLSTATE '45000'
SET MESSAGE_TEXT = 'Output total price cannot be less than 0.';
END IF;

DROP TRIGGER IF EXISTS `Input_count_greater_than_or_equal_to_zero`;

CREATE TRIGGER `Input_count_greater_than_or_equal_to_zero`
BEFORE INSERT
ON `Input`
FOR EACH ROW
IF NEW.`Count` < 0 THEN 
SIGNAL SQLSTATE '45000'
SET MESSAGE_TEXT = 'Input count cannot be less than 0.';
END IF;

DROP TRIGGER IF EXISTS `Product_price_greater_than_or_equal_to_zero`;

CREATE TRIGGER `Product_price_greater_than_or_equal_to_zero`
BEFORE INSERT
ON `Product`
FOR EACH ROW
IF NEW.`Price` < 0 THEN 
SIGNAL SQLSTATE '45000'
SET MESSAGE_TEXT = 'Product price cannot be less than 0.';
END IF;

DROP TRIGGER IF EXISTS `Product_count_greater_than_or_equal_to_zero`;

CREATE TRIGGER `Product_count_greater_than_or_equal_to_zero`
BEFORE INSERT
ON `Product`
FOR EACH ROW
IF NEW.`Count` < 0 THEN 
SIGNAL SQLSTATE '45000'
SET MESSAGE_TEXT = 'Product count cannot be less than 0.';
END IF;