export interface IProductsSettings {
  simulators: string;
  sortableFields: ISortableField[];
  order: string;
  skip: number;
  take: number;
  maxTake: number;
}

export interface ISortableField {
  field: string;
  display: string;
  isSortField: boolean;
}
