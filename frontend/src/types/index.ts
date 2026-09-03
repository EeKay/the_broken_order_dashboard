export const ORDER_STATUSES = [
  "Pending",
  "Processing",
  "Shipped",
  "Delivered",
  "Cancelled",
] as const;

export type OrderStatus = (typeof ORDER_STATUSES)[number];

export interface Order {
  id: number;
  orderNumber: string;
  customerName: string;
  location: string;
  product: string;
  quantity: number;
  total: number;
  orderedBy: string;
  status: OrderStatus;
  createdAt: string;
}

export const STATUS_LABEL: Record<OrderStatus, string> = {
  Pending: "Open",
  Processing: "In uitvoering",
  Shipped: "Onderweg",
  Delivered: "Geleverd",
  Cancelled: "Geannuleerd",
};
