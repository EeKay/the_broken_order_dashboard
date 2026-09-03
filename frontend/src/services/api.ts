import axios from "axios";
import type { Order, OrderStatus } from "../types";

export const api = axios.create({
  baseURL: "http://localhost:5080/api",
});

const token = localStorage.getItem("auth_token");
if (token) {
  api.defaults.headers.common.Authorization = `Bearer ${token}`;
}

export function describeApiError(err: unknown): string {
  if (axios.isAxiosError(err)) {
    if (err.response) {
      return `API ${err.response.status}`;
    }
    return `${err.message}. Geen HTTP-response: draait de API op http://localhost:5080? Open ook de browserconsole.`;
  }
  return err instanceof Error ? err.message : "Onbekende fout";
}

export function setAuthToken(tokenValue: string | null) {
  if (tokenValue) {
    localStorage.setItem("auth_token", tokenValue);
    api.defaults.headers.common.Authorization = `Bearer ${tokenValue}`;
    return;
  }

  localStorage.removeItem("auth_token");
  delete api.defaults.headers.common.Authorization;
}

export async function loginApi(email: string, password: string): Promise<{ token: string; displayName: string }> {
  const { data } = await api.post<{ token: string; displayName: string }>("/auth/login", {
    email,
    password,
  });
  return data;
}

export async function fetchOrdersApi(): Promise<Order[]> {
  const { data } = await api.get<Order[]>("/orders");
  return data;
}

export async function fetchOrderApi(id: number): Promise<Order> {
  const { data } = await api.get<Order>(`/orders/${id}`);
  return data;
}

export async function updateOrderStatusApi(
  id: number,
  status: OrderStatus,
): Promise<Order> {
  const { data } = await api.patch<Order>(`/orders/${id}/status`, { status });
  return data;
}
