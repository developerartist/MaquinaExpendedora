import React, { useEffect, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';

function App() {

  const baseUrl = "https://localhost:44381/api/Producto";
  const [data, setData] = useState([]);

  const peticionGet=async()=>{
    await axios.get(baseUrl)
    .then(response=>{
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

  useEffect(()=>{
    peticionGet();
  },[])
  return (
    <div className="App">
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Id_Producto</th>
            <th>Nombre Producto</th>
            <th>Tamaño Producto</th>
            <th>Marca Producto</th>
            <th>Precio Producto</th>
          </tr>
        </thead>
        <tbody>
          {data.map(producto=>(
            <tr key={producto.id_producto}>
              <td>producto.nombre_producto</td>
              <td>producto.tamaño_producto</td>
              <td>producto.marca_producto</td>
              <td>producto.precio_producto</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default App;
