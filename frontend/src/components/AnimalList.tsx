import React from "react";
import { AppState } from "../reducers/rootReducer";
import { fetchShelter } from "../actions/shelterActions";
import { connect } from "react-redux";
import { Dispatch, compose } from "redux";
import { useParams as params } from "react-router-dom";


export const AnimalList : React.FC<Props> = () => {
    return null;
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
    }
})

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps as any)(AnimalList);