import type { Product } from "../../models/objectTypes";
import style from "./ProductItem.module.css";

interface Props {
    product: Product;
	onDeleteItem(productId: string): void;
}

export function ProductItem({ product, onDeleteItem } : Props) {
    return(
        <div className={style.productContainer}>
			<div className={style.productContainerMain}>
				<div className={style.productData}>
					<div className={style.productData}>{product.name}</div>
					<div className={style.productData}>{product.vendor}</div>
					<div className={style.priceData}>{product.formattedPrice}</div>
				</div>
				<div className={style.categoryList}>
					{product.categories.map((c) => (
						<div key={c.id} className={style.categoryTab}>
							<div className={style.categoryMark} style={{color: c.color}}>&#9632;</div>
							<div>{c.name}</div>
						</div>
					))}
				</div>
			</div>
			<div onClick={() => onDeleteItem(product.id)} className={style.deleteProduct}>
				x
			</div>
        </div>
    )
}