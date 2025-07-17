import { useState } from 'react';
import style from "./NewProductItem.module.css";
import type { NewProduct, Category } from "../../models/objectTypes";

interface Props {
	categories: Category[];
	onProductAdd(newProduct: NewProduct): void | Promise<void>;
	onAddPannelSet(state: boolean): void;
}

export function NewProductItem({categories, onProductAdd, onAddPannelSet} : Props) {
	const [addedCategories, setAddedCategories] = useState<Category[]>([]);
	const [categoryInput, setCategoryInput] = useState('');
	const [isShowSuggestions, setIsShowSuggestions] = useState(false);
	const [productName, setProductName] = useState('');
	const [vendorName, setVendorName] = useState('');
	const [price, setPrice] = useState<number>(0)

	function addCategory(category : Category) {
		setAddedCategories(prev => [...prev, category]);
		setCategoryInput('');
		setIsShowSuggestions(false);
	}

	async function sendNewProduct() {
		const newProduct: NewProduct = {
			name: productName,
			vendor: vendorName,
			price: price,
			categoryIds: addedCategories.map(ac => ac.id)
		}

		await onProductAdd(newProduct);
		onAddPannelSet(false);
	}

	const filteredCategories = categories.filter(c => c.name.toLowerCase().includes(categoryInput.toLowerCase()) && !addedCategories.find(a => a.id === c.id)).slice(0,5);

	console.log(addedCategories);

	return(
		<div className={style.newProductContainer}>
			<div className={style.productData}>
				<div>
					<input placeholder="Name" onChange={(e) => setProductName(e.target.value)}/>
				</div>
				<div>
					<input placeholder="Vendor" onChange={(e) => setVendorName(e.target.value)}/>
				</div>
				<div>
					<input placeholder="Price" pattern="\d*" onChange={(e) => setPrice(parseFloat(e.target.value.replace(',', '.')))}/>
				</div>
			</div>
			<div className={style.categoryList}>
				{addedCategories && addedCategories.length > 0 && addedCategories.map((c) => (
						<div key={c.id} className={style.categoryTab}>
							<div className={style.categoryMark} style={{color: c.color}}>&#9632;</div>
							<div>{c.name}</div>
						</div>
					))
				}
				<input 
					className={style.categoryInput} 
					value={categoryInput}
					placeholder='Category Name'
					onChange={(e) => setCategoryInput(e.target.value)}
					onFocus={() => setIsShowSuggestions(true)}
				/>
				<button className={style.categoryBtn} onClick={() => sendNewProduct()}>
					ADD
				</button>
				{isShowSuggestions && filteredCategories.length > 0 && (
					<div className={style.suggestionList}>
						{filteredCategories.map(c => (
							<div
								key={c.id}
								className={style.suggestionItem}
								onClick={() => {
									addCategory(c);
								}}
							>
								<span className={style.categoryMark} style={{ color: c.color }}>
									&#9632;
								</span>{' '}
								{c.name}
							</div>
						))}
					</div>
				)}
			</div>
		</div>
	)
}