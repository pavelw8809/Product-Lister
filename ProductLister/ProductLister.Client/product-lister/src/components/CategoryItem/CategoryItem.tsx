import type { Category } from "../../models/objectTypes";
import style from "./CategoryItem.module.css";

interface Props {
	category: Category;
}

export function CategoryItem({ category } : Props) {
	return(
		<div className={style.categoryContainer}>
			<div className={style.categoryMark} style={{color: category.color}}>&#9632;</div>
			<div>{category.name}</div>
		</div>
	)
}