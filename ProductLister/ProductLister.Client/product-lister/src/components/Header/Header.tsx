import { NavLink } from "react-router-dom";
import style from "./Header.module.css";

export function Header() {
    return(
        <header>
            <nav className={style.navlink}>
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