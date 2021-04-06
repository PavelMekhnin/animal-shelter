import React, { useState } from "react";
import { AppState } from "../reducers/rootReducer";
import { fetchShelter } from "../actions/shelterActions";
import { connect } from "react-redux";
import { Dispatch } from "redux";
import { Link, useParams as params } from "react-router-dom";
import { AnimalCardPreview } from "../components/AnimalCardPreview";
import '../styles/animal.scss';


const AnimalList: React.FC<Props> = ({ shelter, fetch, loading, getShelterId }) => {
    const [isLoading, setIsLoading] = useState<boolean>(false);

    if (!isLoading && (shelter == null || shelter.id != +getShelterId())) {
        fetch();
        setIsLoading(true);
    }
    var exists = shelter.animals != null && shelter.animals.length > 0;
    const shelterUrl = `/shelter/${shelter.id}`

    return (
        <div className="container">
            <Link to={shelterUrl}>
                <div className="row">
                    <div className="col offset-s4 s4 offset-m5 m2">
                        <div style={{ backgroundImage: "url(" + shelter.logoUrl + ")" }} className="circle square-img logo" />
                    </div>
                </div>
                <div className="row">
                    <h2 className="center-align orange-text">{shelter.title}</h2>
                </div>
            </Link>
            <div className="row">
                <h4 className="center-align orange-text">Our animals</h4>
            </div>
            <div className="row">
                {
                    loading === false ? (
                        exists ?
                            shelter.animals.map(card => {
                                return (
                                    <div className="col s6 m6 l4" key={card.id}>
                                        <AnimalCardPreview card={card} shelterId={shelter.id.toString()} key={card.id}></AnimalCardPreview>
                                    </div>
                                )
                            })
                            :
                            <p>We do not have any animals yet ;(</p>
                    ) : (
                        <div className="progress">
                            <div className="indeterminate"></div>
                        </div>
                    )
                }
            </div>
        </div >
    );
}

interface RouteParams {
    shelterid: string
}
const mapStateToProps = (state: AppState) => {
    return {
        shelter: state.shelters.currentShelter,
        loading: state.app.loading
    }
}

const mapDispatchToProps = (dispatch: Dispatch<any>) => ({
    fetch: () => {
        const route = params<RouteParams>();
        dispatch(fetchShelter(route.shelterid));
    },
    getShelterId: () => params<RouteParams>().shelterid
})

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps as any)(AnimalList);