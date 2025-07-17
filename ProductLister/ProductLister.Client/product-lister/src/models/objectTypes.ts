export interface Category {
    id: string;
    name: string;
    color: string;
}

export interface Product {
    id: string;
    name: string;
    vendor: string;
    price: number;
	formattedPrice: string;
    categories: Category[];
}

export interface NewProduct {
	name: string;
	vendor: string;
	price: number;
	categoryIds: string[]
}