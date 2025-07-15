import { NavLink } from "react-router-dom";

export function Header() {
    return(
        <header>
            <nav>
                <NavLink to="/products" style={({ isActive }) => ({marginRight: 10, fontWeight: isActive ? "bold" : "normal"})}>
                    PRODUCTS
                </NavLink>
                <NavLink to="/categories" style={({ isActive }) => ({marginRight: 10, fontWeight: isActive ? "bold" : "normal"})}>
                    CATEGORIES
                </NavLink>
            </nav>
        </header>
    )
}