import './App.css';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import StaffLogin from './pages/StaffLogin';
import StaffPage from './pages/StaffPage';
import ReservationByStaff from './pages/ReservationByStaff';
import HubSelection from './pages/HubSelection';
import { Abhishek2 } from "../src/pages/Abhishek2";
import  AboutUs  from './Components/AboutUs';
import Signup from './pages/Signup';
import CustomerInfo from './pages/CustomerInfo';
import LoginForm from './pages/LoginForm';
import CustomerCare from './pages/CustomerCare';
import VehicleSelection from './pages/VehicleSelection';
import Addon from './pages/Addon';
import CancleBookingByStaff from './pages/CancleBookingByStaff';
import HandOverDetails from './pages/HandOverDetails';
import BookingDetail from './pages/BookingDetail';
import ModifyCancel from './pages/ModifyCancel';
import Return from './pages/Return';

function App() {
  return (
    <Router future={{ v7_relativeSplatPath: true }}>  
      { <Routes>
        { <Route path="/" element={<Abhishek2 />} /> }
        { <Route path="/Signup" element={<Signup/>} /> }
        { <Route path="/AboutUs" element={<AboutUs/>} /> }
        { <Route path="/CustomerCare" element={<CustomerCare/>} /> }
        { <Route path="/LoginForm" element={<LoginForm/>} />}
        { <Route path="/StaffLogin" element={<StaffLogin />} /> }
        { <Route path="/ReservationByStaff" element={<ReservationByStaff/>} /> }
        { <Route path="/BookingDetail" element={<BookingDetail/>} /> }
        {  <Route path="/HubSelection" element={<HubSelection/>} /> }
        { <Route path="/VehicleSelection" element={<VehicleSelection/>} />}
        {  <Route path="/Addon" element={<Addon/>} />  }
        { <Route path="/CustomerInfo" element={<CustomerInfo/>}/>}
        { <Route path="/StaffPage" element={<StaffPage />} /> }
        { <Route path="/HandOverDetails" element={<HandOverDetails />} /> }
        { <Route path="/CancleBookingByStaff" element={<CancleBookingByStaff />} /> }
        { <Route path="/ModifyCancel" element={<ModifyCancel />} /> }
        { <Route path="/Return" element={<Return />} /> }

      </Routes>
    }
    </Router>
   
  );
}

export default App;
