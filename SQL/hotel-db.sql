CREATE DATABASE IF NOT EXISTS hotel_db;
USE hotel_db;

-- USERS TABLE
CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE,
    password VARCHAR(255) NULL,
    dob DATE,
    nationality VARCHAR(100),
    id_card_number VARCHAR(50),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- CUSTOMERS TABLE
CREATE TABLE customers (
    customer_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    address VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- FOODS TABLE
CREATE TABLE foods (
    food_id INT AUTO_INCREMENT PRIMARY KEY,
    food_name VARCHAR(100) NOT NULL,
    food_type VARCHAR(20),
    description VARCHAR(255),
    price DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- ROOM TYPES TABLE
CREATE TABLE room_types (
    type_id INT AUTO_INCREMENT PRIMARY KEY,
    type_name VARCHAR(50) NOT NULL UNIQUE,
    description VARCHAR(255),
    price_per_night DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- ROOM TABLE
CREATE TABLE rooms (
    room_id INT AUTO_INCREMENT PRIMARY KEY,
    room_number VARCHAR(10) NOT NULL UNIQUE,
    is_available BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    room_type_id INT,
    FOREIGN KEY (room_type_id) REFERENCES room_types(type_id)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

-- BOOKINGS TABLE
CREATE TABLE bookings (
    booking_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    room_id INT,
    check_in_date DATE NOT NULL,
    check_out_date DATE NOT NULL,
    total_amount DECIMAL(10, 2) NULL,
    booking_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    booking_status TINYINT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (room_id) REFERENCES rooms(room_id)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

-- FOOD ORDERS TABLE (Updated)
CREATE TABLE food_orders (
    order_id INT AUTO_INCREMENT PRIMARY KEY,
    booking_id INT,
    order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status ENUM('Paid', 'Ordered') NOT NULL DEFAULT 'Ordered',
    FOREIGN KEY (booking_id) REFERENCES bookings(booking_id)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

-- ORDER ITEMS TABLE (Updated)
CREATE TABLE order_items (
    orderItem_id INT AUTO_INCREMENT PRIMARY KEY,
    order_id INT,
    food_id INT,
    quantity INT NOT NULL,
    description TEXT,
    note TEXT,
    total_price DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
    FOREIGN KEY (order_id) REFERENCES food_orders(order_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (food_id) REFERENCES foods(food_id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
);

-- PAYMENTS TABLE
CREATE TABLE payments (
    payment_id INT AUTO_INCREMENT PRIMARY KEY,
    booking_id INT,
    amount DECIMAL(10, 2) NOT NULL,
    payment_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    payment_status VARCHAR(10),
    payment_method VARCHAR(30),
    FOREIGN KEY (booking_id) REFERENCES bookings(booking_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
