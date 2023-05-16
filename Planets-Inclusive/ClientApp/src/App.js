import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import { QueryClient, QueryClientProvider } from 'react-query';

export default class App extends Component {
  static displayName = App.name;

  render() {
    const client = new QueryClient();
    return (
      <QueryClientProvider client={client}>
        <Layout>
          <Routes>
            {AppRoutes.map((route, index) => {
              const { element, ...rest } = route;
              return <Route key={index} {...rest} element={element} />;
            })}
          </Routes>
        </Layout>
      </QueryClientProvider>
    );
  }
}