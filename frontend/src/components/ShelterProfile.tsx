import { useParams as params} from "react-router-dom";
import React from "react";
import { IShelterCard } from "../interfaces/Interfaces";
import { AnimalCardList } from "./AnimalCardList";
import { ContactsBlock } from "./ContactsBlock";
import { AnimalNeeds } from "./AnimalNeeds";
import { AppState } from "../reducers/rootReducer";
import { connect } from "react-redux";
import { Page404 } from "./404";

const ShelterProfile: React.FC<Props> = ({shelter}) => {
    if(shelter == null){
        return(
            <Page404></Page404>
        )
    }

    return (
        <div className="container">
            <div className="row">
                <div className="cover-img" style={{ backgroundImage: "url(" + shelter.cover_url + ")" }}></div>
            </div>
            <div className="row">
                <div className="col s3 grey lighten-5 center-align">
                    <img className="circle logo-img z-depth-2" src={shelter.img_url} alt="" />
                    <div className="row"><h5>{shelter.title}</h5></div>
                    <div className="row">
                        <div className="left-info-block">
                            <span>Адрес</span>
                            <h6>{shelter.address}</h6>
                        </div>
                    </div>
                    <div className="row"><ContactsBlock list={shelter.contacts}></ContactsBlock></div>
                </div>

                <div className="col s9">
                    <div className="row">
                        <h5>О нас</h5>
                        <p>{shelter.description}</p>
                    </div>
                    <div className="row">
                        <h5>Питомцы</h5>
                        <AnimalCardList list={shelter.animals}></AnimalCardList>
                    </div>
                    <div className="row">
                        <h5>Нужды</h5>
                        <AnimalNeeds list={shelter.needs}></AnimalNeeds>
                    </div>
                </div>
            </div>
        </div>
    )
}

interface RouteParams {
    shelterid: string
}
const mapStateToProps = (state: AppState) => {
    const route = params<RouteParams>();

    console.log(route.shelterid);
    
    const shelters = state.shelters.shelters.filter(x => x.id.toString() == route.shelterid);

    if(shelters.length == 0){
        return null;
    }
    
    return {
        shelter: shelters[0]
    }
}
type Props  = ReturnType<typeof mapStateToProps>;

export default connect(mapStateToProps, null)(ShelterProfile);