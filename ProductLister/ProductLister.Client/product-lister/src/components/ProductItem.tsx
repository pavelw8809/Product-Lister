import type { Product } from "../models/ObjectTypes";
import style from "./ProductItem.module.css";

interface Props {
    product: Product;
}

export function ProductItem({ product } : Props) {
    return(
        <div className={style.productContainer}>
            {props.name}
        </div>
    )
}