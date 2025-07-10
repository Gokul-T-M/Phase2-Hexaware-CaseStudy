import { ECommerceService } from "./services/ecommerce.service";

// Create the service
const shop = new ECommerceService();

// Show products
shop.viewProducts();

// Add products to cart
shop.addToCart(1, 1); // 1 x Laptop
shop.addToCart(2, 2); // 2 x Jeans
shop.addToCart(3, 1); // 1 x Rice Bag

// Remove a product from cart
shop.removeFromCart(2); // Remove Jeans

// Show cart summary
shop.showCartSummary();

// Show updated products
shop.viewProducts();
