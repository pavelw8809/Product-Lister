import React, { useState, useEffect } from "react";
import type { Category, NewProduct, Product } from "../models/objectTypes"

import { ProductItem } from "../components/ProductItem/ProductItem";
import { ProductNavigation } from "../components/ProductNavigation/ProductNavigation";
import { NewProductItem } from "../components/NewProductItem/NewProductItem";

import style from "./Main.module.css";

export function Main() {
    const [search, setSearch] = useState("");
    const [products, setProducts] = useState<Product[]>([]);
	const [categories, setCategories] = useState<Category[]>([]);
    const [pageSize, setPageSize] = useState<number>(10);
	const [totalPages, setTotalPages] = useState<number>(0);
    const [pageNo, setPageNo] = useState<number>(1);
	const [isAddActive, setIsAddActive] = useState<boolean>(false);

    const API_PATH = "https://localhost:7047/api"

    useEffect(() => {
        getProductList();
		getCategoryList();
    }, [])

	async function getCategoryList() {
		const url = `${API_PATH}/categories`;
		
		try {
			const resp = await fetch(url, {
				method: "GET",
				headers: {'Accept': 'application/json'}
			});

			if (resp.ok) {
				const data = await resp.json();

				if (data && data.length > 0) {
					setCategories(data);
				}
			}
		} catch {
			console.log("Error. Could not get product list");
		}
	}

    async function getProductList(page: number = 1, itemsPerPage = 10) {
        let url;

        if (search == null || search.length == 0) {
            url = `${API_PATH}/products?page=${page}&pagesize=${itemsPerPage}`
        } else {
            url = `${API_PATH}/products?name=${search}&page=${page}&pagesize=${itemsPerPage}`
        }

		console.log(url);
		console.log("page url: " + page);

        try {
            const resp = await fetch(url, {
                method: 'GET', 
                headers: {'Accept': 'application/json'}
            });

            if (resp.ok) {
                const data = await resp.json();

				console.log(data);

                if (data) {
					//if (data.totalCount === 0) {
					//	setProducts(data.items)
					//} else {
						setProducts(data.items);
						setPageNo(data.page);
						setTotalPages(data.totalPages);
						setPageSize(data.pageSize);
					//}
                }
            } else {
                console.log("No products were found");
            }
        } catch {
            console.log("Error. Could not get product list");
        }
    }

	async function AddProduct(newProduct: NewProduct) {
		const url = `${API_PATH}/products`;

        try {
            const resp = await fetch(url, {
                method: 'POST', 
                headers: {
					'Accept': 'application/json',
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(newProduct)
            });

			console.log(JSON.stringify(newProduct));

            if (resp.ok) {
                const data = await resp.json();
				console.log(data);
                if (data) {
                    setProducts(prevProducts => [data, ...prevProducts]);
                }
            } else {
                console.log("Response is empty");
            }
        } catch {
            console.log("Error. Could not get product list");
        }
	}

	function setAddPannelState(state: boolean) {
		setIsAddActive(state);
	}

	async function deleteProduct(productId: string) {
		const url = `${API_PATH}/products`;
		try {
			const resp = await fetch(url, {
				method: 'DELETE',
				headers: {
					'Accept': 'application/json',
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(productId)
			});

			if (resp.ok) {
				const data = await resp.json();
				if (data) {
					setProducts(prevProducts => prevProducts.filter(p => p.id !== productId));
				}
			}
		} catch {
			console.log("Error. Could not delete product");
		}
	}

    const listData = products ? products.map((r) => (
        <ProductItem key={r.id} product={r} onDeleteItem={deleteProduct}/>
    )) : <p>No data</p>;

    return(
        <div>
			<div className={style.searchContainer}>
				<input type="text" className={style.searchInput} onChange={(e) => setSearch(e.target.value)}/>
				<button className={style.searchBtn} onClick={() => getProductList()}>Search</button>
			</div>
			<ProductNavigation pageNo={pageNo} totalPages={totalPages} itemsPerPage={pageSize} onPageChange={getProductList} onProdAdd={setAddPannelState}/>
            {isAddActive &&
				<NewProductItem categories={categories} onProductAdd={AddProduct} onAddPannelSet={setAddPannelState}/>
			}
			{listData}
        </div>
    )
}